using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public string nombreNivel = "";
	public int sexo = 1;
	public int nivel = 1;
	public int puntuacionMaxima = 0;
	public int espirales = 0;
	public string mapa1 = "0001";
	public string subMapa1 = "0000";
	public string subMapa2 = "0001";
	public int nivelParejas = 4;

	public static EstadoJuego estadoJuego;

	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);

		DatosAGuardar datos = new DatosAGuardar();
		datos.nombreNivel = nombreNivel;
		datos.puntuacionMaxima = puntuacionMaxima;
		datos.espirales = espirales;
		datos.mapa1 = mapa1;
		datos.subMapa1 = subMapa1;
		datos.subMapa2 = subMapa2;
		datos.nivelParejas = nivelParejas;
		datos.sexo = sexo;
		datos.nivel = nivel;
		bf.Serialize(file, datos);

		file.Close();
	}

	void Cargar(){
		if(File.Exists(rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);

			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);

			nombreNivel = datos.nombreNivel;
			puntuacionMaxima = datos.puntuacionMaxima;
			espirales = datos.espirales;
			mapa1 = datos.mapa1;
			subMapa1 = datos.subMapa1;
			subMapa2 = datos.subMapa2;
			nivelParejas = datos.nivelParejas;
			sexo = datos.sexo;
			nivel= datos.nivel;
			file.Close();
		}else{
			puntuacionMaxima = 0;
		}
	}
}

[Serializable]
class DatosAGuardar{
	public string nombreNivel;
	public int puntuacionMaxima;
	public int espirales;
	public string mapa1;
	public string subMapa1;
	public string subMapa2;
	public int nivelParejas;
	public int sexo;
	public int nivel;

}