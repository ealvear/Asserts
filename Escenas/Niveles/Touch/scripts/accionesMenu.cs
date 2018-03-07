	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI; //para el texto

	public class accionesMenu : MonoBehaviour {
		public Text NombreNamui; //acceder al texto Arecolectados
		public Text NombreEspañol; //acceder al texto Arecolectados
		public TextMesh txtEspirales; //acceder al texto Arecolectados
		public TextMesh txtPuntuacion; //acceder al texto Arecolectados

		private int puntos;
		private int espirales;

	void Awake () {		
		puntos = 0;
		espirales=EstadoJuego.estadoJuego.espirales;

		}
		// Update is called once per frame
		void Update () {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Input.GetMouseButtonDown (0)) {
				if(Physics.Raycast(ray, out hit)) {
					string name = hit.collider.transform.parent.name;

				AumentarPuntuacion (name);

				txtPuntuacion.text = puntos.ToString();

				txtEspirales.text = espirales.ToString();

				separarNombres (name);		 
					
				Destroy (hit.collider.transform.parent.gameObject);

				}
			}
		}


		public void separarNombres(string name){


			string[] nom = name.Split ('_');

			NombreNamui.text = "" + nom [0];

			try {
				string[] nom2 = nom [1].Split ('(');
				NombreEspañol.text = "" + nom2 [0];
				Invoke ("nombreBlanco", 1f);
			} catch {
				print ("cin C");
			}

		}
	public void AumentarPuntuacion(string name){

			if (name.CompareTo ("Namui_Banano(Clone)") == 0) {
				puntos=puntos+3;
			}
			if (name.CompareTo ("Namui_Basura(Clone)") == 0) {
				puntos++;
			}
			if (name.CompareTo ("Namui_Botella(Clone)") == 0) {
				puntos=puntos+5;
			}
			if (name.CompareTo ("Namui_Espiral(Clone)") == 0) {
				espirales++;
			}
		}

		public void nombreBlanco(){
			NombreNamui.text = "";
			NombreEspañol.text = "";

		}

	}
