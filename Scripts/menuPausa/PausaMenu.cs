using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaMenu : MonoBehaviour {
	public GameObject ObjPausa;
	public GameObject botonMenu;

	void  Start (){
		ObjPausa.SetActive(false);
	}

	void  Update (){
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Cambio();
		}
	}

	void  Cambio (){
		if(Time.timeScale == 1)
			Pausear();

		else if(Time.timeScale == 0)
			Continuar();
	}

	public void  Pausear (){
		ObjPausa.SetActive(true);
		Time.timeScale = 0;
	}

	public void  Continuar (){
		ObjPausa.SetActive(false);
		Time.timeScale = 1;

	}

	public void  Menu ( string i  ){
		ObjPausa.SetActive(false);
		Application.LoadLevel(i);
		Time.timeScale = 1;
	}
}