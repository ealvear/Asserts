using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sumador : MonoBehaviour {
	public int sum;
	public SpriteRenderer mapa;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other){
		
		if (sum == 0) {
			//mapa.color= new Color(255, 255, 255, 255);
			NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaMuerto");
		//	SceneManager.LoadScene("sub-Mapa1");
		}
		if (sum == 5) {
			print ("entro");
			Color col= mapa.color;
			col.g = 144;
			col.b = 138;
			mapa.color = col;
				//new Color(255, 144, 138, 255);

		}
		if (sum == 9) {
			mapa.color= new Color(255, 144, 84, 255);

		}
		sum--;
	}
}
