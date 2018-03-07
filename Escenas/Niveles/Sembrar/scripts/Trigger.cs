using UnityEngine;
using System.Collections;
using UnityEngine.UI; //para el texto
public class Trigger : MonoBehaviour {
	public Text NombAnimales; //acceder al texto Arecolectados
	public Text NombAnimalesEspañol; //acceder al texto Arecolectados
	// Use this for initialization
	void Start () {
	
	}
	//para destruir objeto que se encuentra en el tag Objetos

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.CompareTag("Animal") || other.CompareTag("Enemigo")){
			//destruye el objeto en un tiempo de 1.10s
			//Destroy (other.gameObject,0.2f);
			//Debug.Log (other.name);
			char del='_';
			string [] nom= other.name.Split(del);
			try{
				string [] nom2= nom[1].Split('(');
				NombAnimales.text = "" + nom[0];
				NombAnimalesEspañol.text = "" + nom2[0];
				Invoke ("nombreBlanco",5f);
			}catch{
				print ("cin C");
			}



		}

		if(other.CompareTag("Objetos")){
			//destruye el objeto en un tiempo de 1.10s
			Debug.Log ("Objeto");
			//Destroy (other.gameObject,0.2f);

		}


	}

	public void nombreBlanco(){
		NombAnimales.text = "";
		NombAnimalesEspañol.text = "";
	
	}

}
