using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

	public List<GameObject> ListaImagenes;
	public int index =0;
	public int nindex =0;

	// Use this for initialization
	void Start () {

		index = PlayerPrefs.GetInt ("ListaImg");
		ListaImagenes [index].SetActive (true);

	}
	
	// Update is called once per frame
	public void next(){
		ListaImagenes [index].SetActive (false);
		if (index == ListaImagenes.Count - 1) {
			index = 0;
			PlayerPrefs.SetInt ("ListaImg",index);
		} else {
		
			index++;
		}
		ListaImagenes [index].SetActive (true);
		PlayerPrefs.SetInt ("ListaImg",index);


	}

	public void previo(){
		
		ListaImagenes [index].SetActive (false);
		if (index == 0) {
			index = ListaImagenes.Count - 1;
			PlayerPrefs.SetInt ("ListaImg",index);
		} else {

			index--;
		}
		ListaImagenes [index].SetActive (true);
		PlayerPrefs.SetInt ("ListaImg",index);

	}

	void Awake(){
		GameObject[] personajes =  Resources.LoadAll<GameObject> ("Menu");

		foreach (GameObject c in personajes) {
			GameObject _char  = Instantiate(c) as GameObject;
			_char.transform.SetParent (GameObject.Find ("ListaImagenes").transform);

			ListaImagenes.Add (_char);
			_char.SetActive (false);
			//ListaImagenes [index].SetActive (true);
		}
	}

}
