using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NuevoColores : MonoBehaviour {
	Renderer colorSeleccionado;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnMouseDown(){


		for (int i = 0; i < PlayerPrefs.GetInt("Cantidad",0); i++) {

			PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"R"+i, 255);
			PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"G"+i, 255);
			PlayerPrefs.SetFloat (PlayerPrefs.GetString("NombrePersonaje")+"B"+i, 255);

		}

		SceneManager.LoadScene ("Colorear");

	}


}
