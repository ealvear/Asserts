using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cambiarEscena : MonoBehaviour {
	public string escena;
	public int n=-1 ;

	// Use this for initialization


	public void OnMouseDown(){
		EstadoJuego.estadoJuego.nivel=n;
		EstadoJuego.estadoJuego.Guardar();

		SceneManager.LoadScene(escena);
	}

	public void Cambiar(string es){
		SceneManager.LoadScene(es);

	}
	public void CambiarEsNiv(string es){
		escena = es;
		OnMouseDown ();

	}




}
