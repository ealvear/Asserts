using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNiveles : MonoBehaviour {

	public string mapa1;
	public string SubMapa1;
	public string NextSubMapa1;
	public string SubMapa2;
	public string NextSubMapa2;
	//public int SubMapa3;
	void Start () {
		SubM1 ();
		SubM2 ();
	}
	
	// Update is called once per frame
	void SubM1 () {

		if (EstadoJuego.estadoJuego.subMapa1.CompareTo (SubMapa1) == 0) {
			EstadoJuego.estadoJuego.subMapa1 = NextSubMapa1;
			if (EstadoJuego.estadoJuego.subMapa1.CompareTo ("1111") == 0) {
				EstadoJuego.estadoJuego.mapa1 = "0011";
			}

			EstadoJuego.estadoJuego.Guardar ();
		}
	}
	void SubM2 () {

		if (EstadoJuego.estadoJuego.subMapa2.CompareTo (SubMapa2) == 0) {
			EstadoJuego.estadoJuego.subMapa2 = NextSubMapa2;
			EstadoJuego.estadoJuego.Guardar ();
		}
	}


}
