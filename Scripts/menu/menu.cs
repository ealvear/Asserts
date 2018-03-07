using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class menu : MonoBehaviour {

	public TextMesh marcador;
	public TextMesh txtespirales;
	private string escena;
	public GameObject btnContinuar;
	// Use this for initialization

	// Update is called once per frame
	void Start() {
		MostrarContinuar ();
		CargaTexto ();
	}
	void Update () {
		MostrarContinuar ();
		CargaTexto ();
	}
	void OnMouseDown(){
		SceneManager.LoadScene (escena);
	}
	public void CargaAr(string pNombreAR){
		escena = pNombreAR;
		SceneManager.LoadScene (escena);
	}

	public void MostrarContinuar(){

		if (EstadoJuego.estadoJuego.puntuacionMaxima == 0) {
			Debug.Log("EstadoPM = "+EstadoJuego.estadoJuego.puntuacionMaxima);
			btnContinuar.SetActive(false);
		} if (EstadoJuego.estadoJuego.puntuacionMaxima != 0) {
			btnContinuar.SetActive(true);
		}
	}

	public void CargaTexto(){
		marcador.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
		txtespirales.text = EstadoJuego.estadoJuego.espirales.ToString();


	}

	public void salir(){
		Application.Quit();
		Debug.Log("Salir");
	}
}
