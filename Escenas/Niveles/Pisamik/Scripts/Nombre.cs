using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nombre : MonoBehaviour {
	public string nombre;
	public int cantidad;

	// Use this for initialization
	void Start () {


		PlayerPrefs.SetString ("NombrePersonaje",nombre);
		PlayerPrefs.SetInt ("Cantidad",cantidad);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		


}
