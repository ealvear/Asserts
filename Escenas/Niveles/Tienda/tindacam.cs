using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tindacam : MonoBehaviour {
	public TextMesh puntos ;
	public TextMesh espirales;
	// Use this for initialization
	void Start () {
		puntos.text = ""+EstadoJuego.estadoJuego.puntuacionMaxima;
		espirales.text =""+EstadoJuego.estadoJuego.espirales;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
