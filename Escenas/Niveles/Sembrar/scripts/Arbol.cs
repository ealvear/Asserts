using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour {
	public Animator animar;
	public bool choq = false;
	public Transform posicionAcodo;
	public GameObject acodoPrefab;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag ("Enemigo")) {
			choq = true;
			//Destroy (other.gameObject,0.2f);

			GetComponent<AudioSource> ().Play ();
			animar.SetTrigger ("choque");

			Vector3 lugar = new Vector3(Random.Range(1.0f, 8.0f), posicionAcodo.position.y, posicionAcodo.position.z);
			Instantiate (acodoPrefab, lugar, Quaternion.identity);


			//Destroy (gameObject);
		}

	}
}
