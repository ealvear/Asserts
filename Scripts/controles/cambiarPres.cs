using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cambiarPres : MonoBehaviour {
	public string escena;
	public GameObject hombre;
	public GameObject mujer;
	public GameObject Bienvenido;
	public GameObject Nivel1;
	public GameObject Nivel2;
	public GameObject Nivel3;
	public GameObject Nivel4;
	public GameObject Nivel5;
	public GameObject Nivel6;

	// Use this for initialization

	void Start () {


		escena = "cargando";

		if (EstadoJuego.estadoJuego.sexo == 2) {
			
			mujer.SetActive (true);
			hombre.SetActive (false);
		} else {
			mujer.SetActive (false);
			hombre.SetActive (true);
		}

		if (EstadoJuego.estadoJuego.nivel==1) {
			EstadoJuego.estadoJuego.nombreNivel = "Colorear";
			Bienvenido.SetActive (true);
			Nivel1.SetActive (false);
			Nivel2.SetActive (false);
			Nivel3.SetActive (false);
			Nivel4.SetActive (false);
			Nivel5.SetActive (false);
		
		}
		if (EstadoJuego.estadoJuego.nivel==2) {
			EstadoJuego.estadoJuego.nombreNivel = "Runner";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (true);
			Nivel2.SetActive (false);
			Nivel3.SetActive (false);
			Nivel4.SetActive (false);
			Nivel5.SetActive (false);
		}

		if (EstadoJuego.estadoJuego.nivel==3) {
			EstadoJuego.estadoJuego.nombreNivel = "touch";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (false);
			Nivel2.SetActive (true);
			Nivel3.SetActive (false);
			Nivel4.SetActive (false);
			Nivel5.SetActive (false);
		}
		if (EstadoJuego.estadoJuego.nivel==4) {
			EstadoJuego.estadoJuego.nombreNivel ="Parejas";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (false);
			Nivel2.SetActive (false);
			Nivel3.SetActive (true);
			Nivel4.SetActive (false);
			Nivel5.SetActive (false);
		}

		if (EstadoJuego.estadoJuego.nivel==5) {
			EstadoJuego.estadoJuego.nombreNivel = "Misak";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (false);
			Nivel2.SetActive (false);
			Nivel3.SetActive (false);
			Nivel4.SetActive (true);
			Nivel5.SetActive (false);
		}

		if (EstadoJuego.estadoJuego.nivel==6) {
			EstadoJuego.estadoJuego.nombreNivel = "Molino";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (false);
			Nivel2.SetActive (false);
			Nivel3.SetActive (false);
			Nivel4.SetActive (false);
			Nivel5.SetActive (true);
		}
		if (EstadoJuego.estadoJuego.nivel==7) {
			EstadoJuego.estadoJuego.nombreNivel = "Parejas";
			Bienvenido.SetActive (false);
			Nivel1.SetActive (false);
			Nivel2.SetActive (false);
			Nivel3.SetActive (false);
			Nivel4.SetActive (false);
			Nivel5.SetActive (true);
		}
	}


	public void OnMouseDown(){
		SceneManager.LoadScene(escena);
	}

	public void Cambiar(string es){
		SceneManager.LoadScene(es);
	}
}
