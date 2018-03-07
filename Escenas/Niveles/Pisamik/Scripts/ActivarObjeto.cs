using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour {
	public GameObject act;
	public GameObject desact;
	// Use this for initialization
	void Awake () {
		if (EstadoJuego.estadoJuego.nivel==1){

			for (int i = 0; i < PlayerPrefs.GetInt("Cantidad",0); i++) {

				PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"R"+i, 255);
				PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"G"+i, 255);
				PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"B"+i, 255);

			}

		}



			activar (act);
			desactivar (desact);

		

	}
	public void desactivar (GameObject obj) {
		obj.SetActive (false);

	}
		
	public void activar (GameObject obj) {
		obj.SetActive (true);		
	}
}
