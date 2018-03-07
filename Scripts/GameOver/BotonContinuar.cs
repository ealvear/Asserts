using UnityEngine;
using System.Collections;

public class BotonContinuar : MonoBehaviour {
	private AudioSource audio;
	private AudioSource audioBoton;
	public TextMesh puntos;
	public TextMesh espirales;
	//public CircleCollider2D cicleCol;
	//public SpriteRenderer spRenser;
	public string escena;
	// Use this for initialization
	void Start () {
		audio = Camera.main.GetComponent<AudioSource>();
		audioBoton =GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		audio.Stop();
		audioBoton.Play();
		int pun = 0;
		bool ban=int.TryParse(puntos.text, out pun);
		EstadoJuego.estadoJuego.puntuacionMaxima = EstadoJuego.estadoJuego.puntuacionMaxima + pun;
		ban=int.TryParse(espirales.text, out pun);
		EstadoJuego.estadoJuego.espirales = pun;
		EstadoJuego.estadoJuego.Guardar();
		Invoke("CargarNivelJuego", audioBoton.clip.length);

	}

	void CargarNivelJuego(){

		Application.LoadLevel (escena);


	}
}
