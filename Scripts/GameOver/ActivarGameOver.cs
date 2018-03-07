using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	public GameObject camaraGameOver;
	private AudioSource audioCam;
	public AudioClip gameOverClip;
	public TextMesh total;

	public TextMesh GOpuntos;
	public TextMesh GOTotalPuntos;



	public GameObject botonContinuar;
	private BoxCollider colliderContinuar;
	private Animator animatorContinuar;

	// Use this for initialization

	void Start () {		

		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		audioCam =GetComponent<AudioSource>();
		colliderContinuar = botonContinuar.GetComponent<BoxCollider>();
		animatorContinuar= botonContinuar.GetComponent<Animator>();

		animatorContinuar.enabled = false;
		colliderContinuar.enabled=false;
	}

	void PersonajeHaMuerto(Notification notificacion){

		int num;
		bool ban;
		int num2;

		GOpuntos.text = total.text;
		ban=int.TryParse(total.text, out num);
		num2 = num + EstadoJuego.estadoJuego.puntuacionMaxima;
		GOTotalPuntos.text=""+num2;
		audioCam.Stop();
		audioCam.clip = gameOverClip;
		audioCam.loop = false;
		audioCam.Play();


		if( num> 10){
			
			activarBoton ();		
		}
		camaraGameOver.SetActive(true);
	}

	void activarBoton() {
		colliderContinuar.enabled=true;
		animatorContinuar.enabled = true;
	}
}
