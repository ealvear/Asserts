using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class ImgPersonaje : MonoBehaviour {
	//public Transform posicionPersonaje;
	public string escena;
	public int idPersonaje=0;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void CargaAr(string pNombreAR){
		escena = pNombreAR;

		PlayerPrefs.SetInt ("Personaje",idPersonaje);
		SceneManager.LoadScene (escena);


	}

	void OnMouseDown(){


			PlayerPrefs.SetInt ("Personaje",idPersonaje);
			SceneManager.LoadScene (escena);


		}
}
