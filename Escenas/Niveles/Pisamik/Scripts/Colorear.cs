using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorear : MonoBehaviour {
	public AudioSource sol;
	public static float r=0f;
	public static float g=255f;
	public static float b=0f;

	public string NombreR="Misak"+"R1";
	public string NombreG="Misak"+"G1";
	public string NombreB="Misak"+"B1";




	Renderer colorSeleccionado;


	// Use this for initialization
	void Start () {

		Invoke ("nuevo",0f);
		Invoke("cambiamosColor",0);
		colorSeleccionado = GetComponent<Renderer> ();
		//colorSeleccionado.material.SetColor ("_Color",new Color(255f,255f,255f));
		//colorSeleccionado.material.SetColor ("_Color", Color.HSVToRGB(0f, 0f, 0f) );
	}

	// Update is called once per frame
	void Update () {
		r=Sonido.rs;
		g=Sonido.gs;
		b=Sonido.bs;
	}

	void OnMouseDown(){
		PlayerPrefs.SetFloat (NombreR,r);
		PlayerPrefs.SetFloat (NombreG,g);
		PlayerPrefs.SetFloat (NombreB,b);

		Invoke("cambiamosColor",0);
			sol=GetComponent<AudioSource> ();
		sol.Play();
	}

	public void nuevo(){

	
	}

	public void cambiamosColor(){

		this.colorSeleccionado.material.SetColor ("_Color", new Color(PlayerPrefs.GetFloat (NombreR,255)/255,PlayerPrefs.GetFloat (NombreG,255)/255,PlayerPrefs.GetFloat (NombreB,255)/255));

	}
}
