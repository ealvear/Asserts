using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrEscena : MonoBehaviour {
	public string NombreEscena="";

	// Use this for initialization


	// Update is called once per frame
	void OnMouseDown(){
//		Debug.Log ("ir a escena");
		SceneManager.LoadScene (NombreEscena);
	}
}
