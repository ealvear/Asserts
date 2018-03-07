using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour {
	public AudioSource sol;
	public  float r=255f;
	public  float g=0f;
	public  float b=0f;

	public static float rs=255f;
	public static float gs=0f;
	public static float bs=0f;

	// Use this for initialization
	void Update () {

	}

	void OnMouseDown(){
		sol=GetComponent<AudioSource> ();
		sol.Play();
		rs = r;
		gs = g;
		bs = b;
		
	}
	

}
