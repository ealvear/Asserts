using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombrero : MonoBehaviour {
	private Renderer colorSeleccionado;
	public static float r=0f;
	public static float g=255f;
	public static float b=0f;
	// Use this for initialization
	void Start () {
		colorSeleccionado = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		r=Sonido.rs;
		g=Sonido.gs;
		b=Sonido.bs;
		this.colorSeleccionado.material.SetColor ("_Color", new Color(r/255,g/255,b/255));
	}
}
