using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {

	public  GameObject[] obj;
	public float tiempoMin=2f;
	public float tiempoMax = 3f;
	private bool fin = false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

	void PersonajeHaMuerto(){
		fin = true;
	}

	void PersonajeEmpiezaACorrer(Notification notificacion){
		Generar();
	}

	// Update is called once per frame
	void Update () {

	}

	void Generar(){
		if(!fin){
			Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
			Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
		}
	}
}
