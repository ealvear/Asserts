using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	private int espirales = 0;

	public TextMesh marcador;
	public TextMesh txtespirales;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		//NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		espirales=EstadoJuego.estadoJuego.espirales;
		ActualizarMarcador();
	}

	void PersonajeHaMuerto(Notification notificacion){
		
		//	EstadoJuego.estadoJuego.puntuacionMaxima =EstadoJuego.estadoJuego.puntuacionMaxima  + puntuacion;
		//	EstadoJuego.estadoJuego.espirales = EstadoJuego.estadoJuego.espirales + espirales;
		//	EstadoJuego.estadoJuego.Guardar();

			}

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;

		if (puntosAIncrementar < 0) {
			espirales = espirales + (puntosAIncrementar * (-1));	
		} else {
			puntuacion+=puntosAIncrementar;
		}

	
		ActualizarMarcador();
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString();
		txtespirales.text = espirales.ToString ();
	}

	// Update is called once per frame
	void Update () {

	}
}
