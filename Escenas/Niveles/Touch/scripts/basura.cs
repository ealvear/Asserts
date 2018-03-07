using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class basura : MonoBehaviour {

	public int vida = 4;
	public float velocidad;


	public float cadencia = 1f;
	float cadAux = 0;


	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

	void PersonajeHaMuerto(Notification notificacion){
		Destroy(this.gameObject);
	}

	void Update ()
	{
		Debug.DrawRay (transform.position, Vector3.left * .5f);
		//RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f, layerPlanta);

		cadAux += Time.deltaTime;

		
		cadAux = 0;
		transform.position -= Vector3.right * velocidad * Time.deltaTime;
		
	}


}