using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuevoJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EstadoJuego.estadoJuego.puntuacionMaxima = 0;
		EstadoJuego.estadoJuego.mapa1 = "0001";
		EstadoJuego.estadoJuego.subMapa1 = "0001";
		EstadoJuego.estadoJuego.subMapa2 = "0001";
		EstadoJuego.estadoJuego.nivelParejas = 4;
		EstadoJuego.estadoJuego.nivel = 0;
		EstadoJuego.estadoJuego.Guardar();

	}
	

}
