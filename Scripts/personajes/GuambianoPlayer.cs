using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuambianoPlayer : MonoBehaviour {



	//public Text puntuacion; //acceder al texto puntos
	public int contador; //contador de puntos

	public Transform posicionSiembra;
	public Transform posicionHueco;
	public GameObject plantaPrefab;
	public GameObject huecoPrefab;
	public GameObject masPrefab;
	public GameObject menosPrefab;
	private bool enHueco = true;
	public LayerMask mascaraHueco;
	//-------------------------------------------------//
	// Botones camvas principal
	public elementoInteractivo botonIzquierdo;
	public elementoInteractivo botonDerecho;
	public elementoInteractivo botonArriba;
	public elementoInteractivo botonMenu;
	public elementoInteractivo btnSembrar;
	public elementoInteractivo btnCavar;
	public elementoInteractivo btnCesto;
	//-------------------------------------------------//
	// elementos del personaje guambiano
	Rigidbody2D guambianoRB;
	Animator guambianoAnim;
	SpriteRenderer guambianoRender;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.1f;
	private AudioSource audio;
	public LayerMask mascaraSuelo;

	//-------------------------------------------------//
	// variables del personake guambiano
	public float maxVelocidad;
	bool voltearGuambiano = true;
	private bool dobleSalto = false;
	public bool enSuelo = true;
	public float fuerzaSalto = 100f;
	private float mover;
	public bool cestoRecolectar;
	//-------------------------------------------------//
	//cambas de el pausa menu
	public Canvas pausaMenu;


	//-------------------------------------------------//
	public void Awake(){
		contador = 0;
		//puntuacion.text = "Plantas: "+contador;
		cestoRecolectar=true;

	}

	// inicializacion de la escena 
	void Start () {

		btnCesto.pulsado=false;
		guambianoRB = GetComponent<Rigidbody2D> ();
		guambianoRender = GetComponent<SpriteRenderer> ();
		guambianoAnim = GetComponent<Animator> ();
		audio=GetComponent<AudioSource>();
		//pausaMenu = GetComponent<Canvas>();
		//pausaMenu.enabled = false;
	}
	//-------------------------------------------------//
	void FixedUpdate(){

		guambianoRB.velocity = new Vector2 (mover*maxVelocidad, guambianoRB.velocity.y); 
		// hacer que el caballero corra 
		guambianoAnim.SetFloat("velMovimiento",Mathf.Abs(mover));
		guambianoAnim.SetFloat("VelVertical", GetComponent<Rigidbody2D>().velocity.y);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		guambianoAnim.SetBool("EnSuelo", enSuelo);
		enHueco= Physics2D.OverlapCircle (posicionHueco.position, comprobadorRadio, mascaraHueco);
		if(enSuelo){
			dobleSalto = false;
		}

	}

	// Actualizacion de cada photograma
	void Update () {


		//if (Input.GetKey ("down")) {

		//	GetComponent<Animator> ().SetBool ("Recoger", true);

		//} else {
		//	GetComponent<Animator> ().SetBool ("Recoger", false);
		//}

		cesto ();


		//sembrar
		if ((contador > 0) && (btnSembrar.pulsado == true) && (enHueco == true) || (contador > 0) && (Input.GetKeyDown ("down") && (enHueco == true))) {

			GetComponent<Animator> ().SetBool ("Sembrar", true);



		} else {
			GetComponent<Animator> ().SetBool ("Sembrar", false);
		}


		Sembrar ();
		Cavar ();


		if (botonIzquierdo.pulsado ) {
			mover = 1;
		} else if (botonDerecho.pulsado) {
			mover = -1;
		} else {
			mover=Input.GetAxis("Horizontal");
		}

		if (Input.GetKey("up") || botonArriba.pulsado) {

			if(enSuelo || !dobleSalto){
				audio.Play();
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);

				if(!dobleSalto && !enSuelo){
					dobleSalto = true;
				}
			}

		} 


		if(mover > 0 && !voltearGuambiano){
			Voltear ();
		}else if (mover<0 && voltearGuambiano){
			Voltear();		}

		//**********************************************************


		if (enSuelo==true && botonArriba.pulsado == true || (Input.GetKey("up") && enSuelo==true) ) {
			GetComponent<Animator> ().SetBool ("EnSuelo", false);

			GetComponent<Rigidbody2D>().AddForce (new Vector2(0, fuerzaSalto)); 

		} else {
			GetComponent<Animator> ().SetBool ("EnSuelo",true);
		}


		//
		if ((btnCavar.pulsado == true && enSuelo==true && !enHueco) || (Input.GetKeyDown("space") && enSuelo==true && !enHueco) ) {
			GetComponent<Animator> ().SetBool ("Cavar", true);

			//GetComponent<Rigidbody2D>().AddForce (new Vector2(0, fuerzaSalto)); 

		} else {
			GetComponent<Animator> ().SetBool ("Cavar",false);
		}

		// recolectar
		if ((btnCesto.pulsado == true && enSuelo==true)) {

			if (cestoRecolectar == true) {



				cestoRecolectar = false;
				//velocidadD = 0.05f;
				GetComponent<Animator> ().SetBool ("Recolectar", true);

			} else {


				cestoRecolectar = true;
			//	velocidadD = 0.08f;
				GetComponent<Animator> ().SetBool ("Recolectar", false);
			}

			btnCesto.pulsado = false;
			//GetComponent<Rigidbody2D>().AddForce (new Vector2(0, fuerzaSalto)); 

		} 



		

	}
	void Voltear(){
		voltearGuambiano = !voltearGuambiano;
		guambianoRender.flipX = !guambianoRender.flipX;
	}
		

	void UpdateState(string state = null){
		if(state != null){
			guambianoAnim.Play (state);
		}
	}

	public void Sembrar(){
		Instantiate (plantaPrefab, (posicionSiembra.position), posicionSiembra.rotation);

		btnSembrar.pulsado = false;
		contador--;
		actualizarPuntuacion ();
	}

	public void Cavar(){

		Instantiate (huecoPrefab, (posicionHueco.position), posicionHueco.rotation);
		btnCavar.pulsado = false;

	}

	public void actualizarPuntuacion(){
	//	puntuacion.text = "Plantas: "+contador;
	}

	public void cesto(){


		if (botonDerecho.pulsado == true || Input.GetKey ("right")) {
			if (GetComponent<SpriteRenderer> ().flipX == false) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}

			GetComponent<Animator> ().SetBool ("RecolectarMover", true);
			//transform.Translate (velocidadD, 0, 0);
			transform.Rotate (0, 0, 0, Space.World);
		} else {
			if (botonIzquierdo.pulsado == true || Input.GetKey ("left")) {
				if (GetComponent<SpriteRenderer> ().flipX == false) {
					GetComponent<SpriteRenderer> ().flipX = true;
				}

				GetComponent<Animator> ().SetBool ("RecolectarMover", true);
				//transform.Translate (-velocidadD, 0, 0);
				transform.Rotate (0, 0, 0, Space.World);
			} else {

				GetComponent<Animator> ().SetBool ("RecolectarMover", false);


			}
		}



	}
	// colisiones
	public void OnCollisionEnter2D(Collision2D colision)
	{
		//Debug.Log ("colision"+colision.gameObject.name);
		if (colision.gameObject.tag == "Objetos" && cestoRecolectar == false && (contador<5)) {
			contador++;

			Destroy (colision.gameObject);
			actualizarPuntuacion ();

			Instantiate (masPrefab, colision.transform.position, Quaternion.identity);

		}
		if (colision.gameObject.tag == "Enemigo" && cestoRecolectar == false && (contador>0)) {
			contador--;
			Instantiate (menosPrefab, colision.transform.position, Quaternion.identity);
			actualizarPuntuacion ();

		}

	}


}
