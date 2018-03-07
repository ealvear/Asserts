using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPisamik : MonoBehaviour {
	public Animator Paleta;
	int band=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		Debug.Log ("Probando Ocultar");
		if (band == 0) {
			Paleta.SetBool("Ocultar", true);
			band = 1;
		}
			
		else{
			Paleta.SetBool("Ocultar", false);
			band = 0;
		}
			



	}
}
