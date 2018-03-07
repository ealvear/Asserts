using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CrearCartas : MonoBehaviour
{
	public GameObject CartaPrefab;
	public GameObject menuGanar;

	public int ancho;
	public Transform CartasParent;
	private List<GameObject> cartas = new List<GameObject> ();

	public Material[] materiales;
	public Texture2D[] texturas;
	public Carta principal;


	public int contadorClicks;
	public Text textoContadorIntentos;
	// Use this for initialization
	public Carta cartaMostrada;
	public bool sePuedeMostrar;

	public int contParejas;
	public int segundosCronometro;
	public Text txtCronometro;
	public Text txtMenuGanador;
	TimeSpan tiempo;

	void Start ()
	{
		ancho = EstadoJuego.estadoJuego.nivelParejas;
		Crear ();
	 
	}

	public void Reiniciar ()
	{
		cartas.Clear ();
		GameObject[] cartasEli = GameObject.FindGameObjectsWithTag ("Carta");
		for (int i = 0; i < cartasEli.Length; i++) {
			DestroyImmediate (cartasEli [i]);
		}
		contadorClicks = 0;
		textoContadorIntentos.text = "Intentos :";
		cartaMostrada = null;
		sePuedeMostrar = true;
		contParejas = 0;
		reiniciarCronometro ();
		activarCronometro ();

		Crear ();
	
	}

	public void Crear ()
	{
		activarCronometro ();
		int cont = 0;
		for (int i = 0; i < ancho; i++) {
			for (int j = 0; j < ancho; j++) {
				float factor = 9.0f / ancho;
				Vector3 posicionTemp = new Vector3 (j * factor, i * factor, 0);
				GameObject cartaTemp = Instantiate (CartaPrefab, posicionTemp, Quaternion.Euler (new Vector3 (0, 180, 0)));
				cartaTemp.transform.localScale *= factor;
				cartas.Add (cartaTemp);

				cartaTemp.GetComponent<Carta> ().posicionOriginal = posicionTemp;
				//cartaTemp.GetComponent<Carta> ().PonerColor(texturas[0]) ;
				//cartaTemp.GetComponent<Carta> ().NumCarta = cont;
				cartaTemp.transform.parent = CartasParent;
				cont++;

			}

		}
		AsignarTexturas ();
		Barajar ();
	}

	void AsignarTexturas ()
	{

		int[] arrayTemp = new int[texturas.Length]; 

		for (int i = 0; i < texturas.Length - 1; i++) {
			arrayTemp [i] = i;
		}

		for (int j = 0; j < arrayTemp.Length; j++) {
			int tmp = arrayTemp [j];
			int r = UnityEngine.Random.Range (j, arrayTemp.Length); 
			arrayTemp [j] = arrayTemp [r];
			arrayTemp [r] = tmp;
		}

		int[] arrayDefinitivo = new int[ancho * ancho];

		int limite = 0;
		if (arrayTemp.Length < arrayDefinitivo.Length) {
			limite = arrayTemp.Length;
		} else {
			limite = arrayDefinitivo.Length;
		}

		for (int i = 0; i < limite; i++) {
			//print ("i = " + i);
			arrayDefinitivo [i] = arrayTemp [i];
		}
//
		for (int i = 0; i < arrayDefinitivo.Length; i++) {
			//print("arra ="+ i / 2);
			cartas [i].GetComponent<Carta> ().AsignarleTextura (texturas [(arrayDefinitivo [i / 2])]);
			cartas [i].GetComponent<Carta> ().NumCarta = i / 2;
			cartas [i].GetComponent<Carta> ().nombre = texturas [(arrayDefinitivo [i / 2])].name;

		}
	}

	void Barajar ()
	{		
		int aleatorio;
		for (int i = 0; i < cartas.Count; i++) { 			
			aleatorio = UnityEngine.Random.Range (i, cartas.Count);
			cartas [i].transform.position = cartas [aleatorio].transform.position;
			cartas [aleatorio].transform.position = cartas [i].GetComponent<Carta> ().posicionOriginal;
			cartas [i].GetComponent<Carta> ().posicionOriginal = cartas [i].transform.position;
			cartas [aleatorio].GetComponent<Carta> ().posicionOriginal = cartas [aleatorio].transform.position;

			//cartasTemp.RemoveAt (aleatorio);
		}

	}

	public void HacerClick (Carta _carta)
	{
	
		if (cartaMostrada == null) {
			cartaMostrada = _carta;
		} else {
			
			contadorClicks++;
			//print (contadorClicks);
			ActualizarUI ();

			if (CompararCartas (_carta.gameObject, cartaMostrada.gameObject)) {
				print ("Muy bien ! Has encotrado una pareja ");
				contParejas++;
				principal.AsignarleTextura (cartaMostrada.texturaAnverso);
				principal.MostrarPrincipal ();


				if (contParejas == cartas.Count / 2) {
					menuGanar.SetActive (true);
					txtMenuGanador.text = "HAS GANADO" + '\n' + "Has encontrado todas las parejas en : " + '\n' + tiempo;
					print ("EXELENTE ! Has encotrado todas las parejas ");
				
				}
			} else {

				_carta.EsconderCarta ();
				cartaMostrada.EsconderCarta ();
			}
			cartaMostrada = null;
		}

	}

	public bool CompararCartas (GameObject carta1, GameObject carta2)
	{
		bool resultado;
		if (carta1.GetComponent<Carta> ().NumCarta == carta2.GetComponent<Carta> ().NumCarta) {
			resultado = true;
		} else {
			resultado = false;
		}
		return resultado;
	}


	public void ActualizarUI ()
	{
		textoContadorIntentos.text = "Intentos : " + contadorClicks;
	}


	//******************************************
	//tiempo
	//******************************************
	public void activarCronometro ()
	{
		actualizarCronometro ();
	
	}

	public void reiniciarCronometro ()
	{
		segundosCronometro = 0;
		CancelInvoke ("actualizarCronometro");
	}

	public void pausarCronometro ()
	{

	}

	public void actualizarCronometro ()
	{
		segundosCronometro++;

		tiempo = new TimeSpan (0, 0, segundosCronometro);
		txtCronometro.text = tiempo.ToString ();
		Invoke ("actualizarCronometro", 1.0f);
	}



}
