using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPersonaje : MonoBehaviour {
	public GameObject[] obj;

	public  int per=1;
	// Use this for initialization
	void Start () {

		Invoke ("instancia",0f);



		if (EstadoJuego.estadoJuego.nivel == 1) {
			if (EstadoJuego.estadoJuego.sexo == 1) {
				per = 0;
			} 
			if (EstadoJuego.estadoJuego.sexo == 2) {
				per = 1;
			} 
		} else {
			per=PlayerPrefs.GetInt ("Personaje");
		}




	}

	// Update is called once per frame
	void Update () {
		//per = Juego.nPersonaje;
	}


	public void instancia(){


		Instantiate (obj[per], (obj[per].transform.position), Quaternion.identity);
	}




}
