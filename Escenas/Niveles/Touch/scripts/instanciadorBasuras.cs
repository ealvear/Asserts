	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class instanciadorBasuras : MonoBehaviour {

		public  GameObject[] obj;
		public float tiempoMin=2f;
		public float tiempoMax = 3f;
		private bool fin = false;

	
		void Start()
		{
			Generar ();
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		}

		void PersonajeHaMuerto(Notification notificacion){
		Destroy(this.gameObject);
		}

		void Generar(){
			if(!fin){
			Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
				Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
			}
		}
	}