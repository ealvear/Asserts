using UnityEngine;
using System.Collections;
using UnityEngine.UI; //para el texto
using UnityEngine.SceneManagement;
public class Mover : MonoBehaviour {
	public Animator animar;
	public Animator Nacimiento;


	public Text ARecolectados; //acceder al texto Arecolectados
	public Text Asembrados; //acceder al texto ASembrados
	public int CantidadArbolesRecolectados=0; //contador de puntos
	public int CantidadArboles=0;

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
	private bool enSueloSiembra = true;
	public LayerMask mascaraSueloSiembra;
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
		CantidadArbolesRecolectados = 4;
		CantidadArboles = 0;
		ARecolectados.text = ""+CantidadArbolesRecolectados;
		Asembrados.text = "" + CantidadArboles;
		cestoRecolectar=true;

	}
	void Update () {


		cesto ();


		//sembrar
		accionSembrar();

		
		movimientos ();


		//Hacer Hueco
		accionHueco();


		// recolectar
		accionRecolectar();



	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		enSueloSiembra = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSueloSiembra);

		enHueco= Physics2D.OverlapCircle (posicionHueco.position, comprobadorRadio, mascaraHueco);

	}




	public void Sembrar(){
		Instantiate (plantaPrefab, (posicionSiembra.position), posicionSiembra.rotation);

		btnSembrar.pulsado = false;
		CantidadArbolesRecolectados--;
		CantidadArboles++;
		actualizarPuntuacion ();
	}

	public void Cavar(){

			Instantiate (huecoPrefab, (posicionHueco.position), posicionHueco.rotation);
			btnCavar.pulsado = false;

	}

	public void actualizarPuntuacion(){
		ARecolectados.text = ""+CantidadArbolesRecolectados;
		Asembrados.text = "" + CantidadArboles;

		if (CantidadArboles == 1) {
			Nacimiento.SetBool("ActivarNacimineto", true);

			Debug.Log ("Mision Cumplida");
			Invoke ("irEscena", 6f);

		}

	}

	public void irEscena(){
		SceneManager.LoadScene ("sub-Mapa1");
	}

	public void accionHueco(){
		if ((btnCavar.pulsado == true && enSueloSiembra==true && !enHueco) || (Input.GetKeyDown("space") && enSueloSiembra==true && !enHueco) ) {
			GetComponent<Animator> ().SetBool ("Cavar", true);


		} else {
			GetComponent<Animator> ().SetBool ("Cavar",false);
		}
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

	public void accionRecolectar(){
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

	public void accionSembrar(){
		if ((CantidadArbolesRecolectados > 0) && (btnSembrar.pulsado == true && enHueco == false ) || (CantidadArbolesRecolectados > 0) && (Input.GetKeyDown ("down") && (enHueco == false))) {

			GetComponent<Animator> ().SetBool ("Sembrar", true);



		} else {
			GetComponent<Animator> ().SetBool ("Sembrar", false);
		}
	
	}


	public void movimientos(){
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


		//Saltar

		if ((enSuelo==true || enSueloSiembra==true ) && btnArriba.pulsado == true || (Input.GetKey("up") && (enSuelo==true || enSueloSiembra==true )) ) {
			GetComponent<Animator> ().SetBool ("Saltar", true);

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,fuerzaSalto); 

		} else {
			GetComponent<Animator> ().SetBool ("Saltar",false);
		}
	}



	// colisiones
	public void OnCollisionEnter2D(Collision2D colision)
	{
		//Debug.Log ("colision"+colision.gameObject.name);
		if (colision.gameObject.tag == "Objetos" && cestoRecolectar == false && (CantidadArbolesRecolectados<5)) {
			CantidadArbolesRecolectados++;

			Destroy (colision.gameObject);
			actualizarPuntuacion ();

			Instantiate (masPrefab, colision.transform.position, Quaternion.identity);

		}
		if (colision.gameObject.tag == "Enemigo" && cestoRecolectar == false && (CantidadArbolesRecolectados>0)) {
			CantidadArbolesRecolectados--;
			Instantiate (menosPrefab, colision.transform.position, Quaternion.identity);
			actualizarPuntuacion ();

		}
		
	}



}

