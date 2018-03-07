using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class habDesGameObjet : MonoBehaviour {
	
	// Use this for initialization
	public void desactivar (GameObject obj) {
		obj.SetActive (false);

	}
	

	public void activarNuevoJuego (GameObject obj) {
		if (EstadoJuego.estadoJuego.puntuacionMaxima == 0) {
			SceneManager.LoadScene ("personajes");

		} else {
			obj.SetActive (true);
		}
	}

	public void activar (GameObject obj) {
								obj.SetActive (true);		
	}
}