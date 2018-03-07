using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
			GameObject personaje = GameObject.Find("Personajes");
			personaje.SetActive(false);
		}else{
			Destroy(other.gameObject);
		}
	}
}
