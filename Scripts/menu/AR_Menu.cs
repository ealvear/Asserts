using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class AR_Menu : MonoBehaviour {
	private AudioSource audio;
	private AudioSource audioBoton;
	private string escena;

	// Use this for initialization
	void Start () {
		audio = Camera.main.GetComponent<AudioSource>();
		audioBoton =GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){

		SceneManager.LoadScene (escena);
	}

	public void CargaAr(string pNombreAR){
		escena = pNombreAR;
		audio.Stop();
		audioBoton.Play();
		Invoke("OnMouseDown", audioBoton.clip.length);
	
	}

	public void seleccionarSexo(int sex){
		escena = "Mapa";
		EstadoJuego.estadoJuego.sexo=sex;
		audio.Stop();
		audioBoton.Play();
		Invoke("OnMouseDown", audioBoton.clip.length);

	}

	public void Salir () {
		Application.Quit();
		Debug.Log ("Saliendoo");
	}


}
