using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //para el texto

public class Carta : MonoBehaviour {

	public int NumCarta = 0;
	public Vector3 posicionOriginal;
	public Texture2D texturaAnverso;
	public Texture2D texturaReverso;
	public string nombre;

	public GameObject ObjNamui;
	public GameObject ObjEspa;
	public GameObject PObjNamui;
	public GameObject PObjEspa;


	public float tiempoDelay;
	public GameObject crearCartas;
	private bool Mostrando;
	// Use this for initialization
	public Text NombreNamui; //acceder al texto Arecolectados
	public Text NombreEspañol; //acceder al texto Arecolectados

	public Text PNombreNamui; //acceder al texto Arecolectados
	public Text PNombreEspañol; //acceder al texto Arecolectados


	void Awake(){
		crearCartas = GameObject.Find ("scripts");
		ObjNamui = GameObject.Find ("NomNamui");
		ObjEspa = GameObject.Find ("NomEspañol");
		NombreNamui= ObjNamui.GetComponent<Text>(); 
		NombreEspañol= ObjEspa.GetComponent<Text>();



	}


	void Start(){
		EsconderCarta ();

	}

	void OnMouseDown() {
		//print (NumCarta.ToString ());
		MostrarCarta ();
		
	}

	// Update is called once per frame
	public void AsignarleTextura(Texture2D _textura) {
		texturaAnverso = _textura;

		//texturaReverso = GetComponent<MeshRenderer> ().material;

	}

	public void MostrarPrincipal() {

		PObjNamui = GameObject.Find ("NomNamuiP");
		PObjEspa = GameObject.Find ("NomEspañolP");
		PNombreNamui= PObjNamui.GetComponent<Text>(); 
		PNombreEspañol= PObjEspa.GetComponent<Text>();
			
			GetComponent<MeshRenderer> ().material.mainTexture = texturaAnverso;
			//Invoke ("EsconderCarta",tiempoDelay);
		nombre=GetComponent<MeshRenderer> ().material.mainTexture.name;
		//print(" nom = "+nombre);
		string [] nom= nombre.Split('_');
		PNombreNamui.text=""+nom[0];
		PNombreEspañol.text=""+nom[1];
		//colorCarta = textura;
	}



	public void MostrarCarta() {
	
		if(!Mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostrar){
			Mostrando = true;
		GetComponent<MeshRenderer> ().material.mainTexture = texturaAnverso;

			string [] nom= nombre.Split('_');

			NombreNamui.text=""+nom[0];
			NombreEspañol.text=""+nom[1];
			//Invoke ("EsconderCarta",tiempoDelay);
		crearCartas.GetComponent<CrearCartas>().HacerClick(this);




		}
		//colorCarta = textura;
	}

	public void EsconderCarta() {
		Invoke ("Esconder",tiempoDelay);

		crearCartas.GetComponent<CrearCartas> ().sePuedeMostrar = false;
		//colorCarta = textura;

	} 
	public void Esconder() {

		GetComponent<MeshRenderer> ().material.mainTexture = texturaReverso;
		Mostrando = false;
		NombreNamui.text="";
		NombreEspañol.text="";
		crearCartas.GetComponent<CrearCartas> ().sePuedeMostrar = true;
		//colorCarta = textura;
	} 




}
