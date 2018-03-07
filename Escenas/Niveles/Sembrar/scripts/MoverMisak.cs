using UnityEngine;
using System.Collections;
using UnityEngine.UI; //para el texto

public class MoverMisak : MonoBehaviour {
	public Animator animar;

	public Text puntuacion; //acceder al texto puntos
	public int contador; //contador de puntos

	public Transform posicionSiembra;
	public Transform posicionHueco;
	public GameObject plantaPrefab;
	public GameObject huecoPrefab;
	public GameObject masPrefab;
	public GameObject menosPrefab;

	public Botones btnIzquierdo;
	public Botones btnDerecha;
	public Botones btnArriba;
	public Botones btnSembrar;
	public Botones btnCavar;
	public Botones btnCesto;

	public bool cestoRecolectar;

	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio=0.15f;
	public LayerMask mascaraSuelo;

	private bool enHueco = true;
	public LayerMask mascaraHueco;


	public float velocidadD = 0.05f;
	public float fuerzaSalto = 600f;

	//***************************************
	public Canvas pausaMenu;


	//***************************************


	public static int a=0;
	public void derec(){
		a = 1;
	}

	// Use this for initialization
	void Start () {
		btnCesto.pulsado=false;
		transform.Rotate(0,0,0,Space.World);

	}

	// Update is called once per frame
	public void Awake(){
		contador = 0;
		puntuacion.text = ""+contador;
		cestoRecolectar=true;

	}


	void Update () {

		//		if (Input.GetKey ("down")) {

		//			GetComponent<Animator> ().SetBool ("Sembrar", true);

		//		} else {
		//			GetComponent<Animator> ().SetBool ("Sembrar", false);
		//		}

		cesto ();


		//sembrar
		if ((contador > 0) && (btnSembrar.pulsado == true) && (enHueco == true) || (contador > 0) && (Input.GetKeyDown ("down") && (enHueco == true))) {

			GetComponent<Animator> ().SetBool ("Sembrar", true);



		} else {
			GetComponent<Animator> ().SetBool ("Sembrar", false);
		}

		//Caminar hacia la izquierda
		if (btnIzquierdo.pulsado == true || Input.GetKey("left")) {
			if (GetComponent<SpriteRenderer> ().flipX == true) {
				GetComponent<SpriteRenderer> ().flipX = false;
			}

			animar.SetBool ("Correr", true);
			transform.Translate (-velocidadD,0,0);
		} else {
			animar.SetBool ("Correr", false);
		}

		//Caminar hacia la derecha
		if (btnDerecha.pulsado == true || Input.GetKey("right")) {
			if (GetComponent<SpriteRenderer> ().flipX == false) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}

			GetComponent<Animator> ().SetBool ("Correr",true);
			transform.Translate (velocidadD,0,0);
			transform.Rotate(0,0,0,Space.World);

		}


		//recoger



		if (enSuelo==true && btnArriba.pulsado == true || (Input.GetKey("up") && enSuelo==true) ) {
			GetComponent<Animator> ().SetBool ("Saltar", true);

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,fuerzaSalto); 

		} else {
			GetComponent<Animator> ().SetBool ("Saltar",false);
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
				velocidadD = 0.05f;
				GetComponent<Animator> ().SetBool ("Recolectar", true);

			} else {


				cestoRecolectar = true;
				velocidadD = 0.08f;
				GetComponent<Animator> ().SetBool ("Recolectar", false);
			}

			btnCesto.pulsado = false;
			//GetComponent<Rigidbody2D>().AddForce (new Vector2(0, fuerzaSalto)); 

		} 


	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);

		enHueco= Physics2D.OverlapCircle (posicionHueco.position, comprobadorRadio, mascaraHueco);

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
		puntuacion.text = ""+contador;
	}

	public void cesto(){


		if (btnDerecha.pulsado == true || Input.GetKey ("right")) {
			if (GetComponent<SpriteRenderer> ().flipX == false) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}

			GetComponent<Animator> ().SetBool ("RecolectarMover", true);
			transform.Translate (velocidadD, 0, 0);
			transform.Rotate (0, 0, 0, Space.World);
		} else {
			if (btnIzquierdo.pulsado == true || Input.GetKey ("left")) {
				if (GetComponent<SpriteRenderer> ().flipX == false) {
					GetComponent<SpriteRenderer> ().flipX = true;
				}

				GetComponent<Animator> ().SetBool ("RecolectarMover", true);
				transform.Translate (-velocidadD, 0, 0);
				transform.Rotate (0, 0, 0, Space.World);
			} else {

				GetComponent<Animator> ().SetBool ("RecolectarMover", false);


			}
		}



	}
	// colisiones
	public void OnCollisionEnter2D(Collision2D colision)
	{
		if (enSuelo == true) {
			transform.parent = colision.transform;
		} else {
			transform.parent = null;
		}
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


	void OnBecameInvisible(){
		transform.position = new Vector3 (-160f, 0f, 0f);
	}



}

