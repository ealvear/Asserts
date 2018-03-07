using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa1 : MonoBehaviour {

	// Use this for initialization
	public string mp1;
	//public int numObjetos=1;
	public GameObject []niveles =null;


	void Awake(){
		//niveles=new GameObject[numObjetos];

		if (mp1.CompareTo("map")==0) {
			mp1 = EstadoJuego.estadoJuego.mapa1;
		}
		if (mp1.CompareTo("sub1")==0) {
			mp1 = EstadoJuego.estadoJuego.subMapa1;
			EstadoJuego.estadoJuego.nivelParejas = 4;


		}
		if (mp1.CompareTo("sub2")==0) {
			mp1 = EstadoJuego.estadoJuego.subMapa2;
			EstadoJuego.estadoJuego.nivelParejas = 6;

		}

			//Debug.Log (mp1.Length +"  son iguales "+ niveles.Length);

		for(int i=0; i<=niveles.Length-1; i++){
			
			if (mp1[i].Equals('1')) {
				niveles[i].GetComponent<SpriteRenderer>().color=Color.green;
				niveles[i].GetComponent<CircleCollider2D>().enabled = true;

			} else {
				niveles[i].GetComponent<SpriteRenderer>().color=Color.red;
				niveles[i].GetComponent<CircleCollider2D>().enabled = false;
			}
		}

				
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//vmp1 = new string[mp1.Length];
		//vmp1=mp1.GetEnumerator;
			
		//Debug.Log (mp1[3]);


		
	}
}
