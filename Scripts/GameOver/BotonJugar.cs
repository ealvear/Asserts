using UnityEngine;
using System.Collections;

public class BotonJugar : MonoBehaviour {
	private AudioSource audio;
	private AudioSource audioBoton;
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
		Invoke("CargarNivelJuego", audioBoton.clip.length);
	}

	void CargarNivelJuego(){
		Application.LoadLevel (escena);
	}
}
