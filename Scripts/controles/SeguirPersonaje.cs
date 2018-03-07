using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour {

	private Transform personaje;
	public GameObject hombre;
	public GameObject mujer;


	public float separacion = 3f;
	
	// Update is called once per frame

	void Awake () {
		hombre.SetActive (true);
	
		if (EstadoJuego.estadoJuego.sexo == 2) {
			print ("mujer");

			personaje = mujer.GetComponent<Transform>();
			hombre.SetActive (false);
			mujer.SetActive (true);

		} 
		if (EstadoJuego.estadoJuego.sexo == 1) {
			print ("hombre");
		
			personaje = hombre.GetComponent<Transform>();

			mujer.SetActive (false);
			hombre.SetActive (true);
		} 


	}

	void Update () {
		transform.position = new Vector3 (personaje.position.x + separacion, transform.position.y, transform.position.z);
	}
}
