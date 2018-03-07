using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hablar : MonoBehaviour {
	public int tiempo;

	public Animator animator;
	public Text mensaje;
	public Text lenguaje;
	public GameObject nuve;
	public string palabraEspanol;
	public string palabraNamui;
	// Use this for initialization
	private bool boolnamui = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void  hablar()
	{
		Invoke ("mensajes",0);
		animator.SetBool("hola", true);
		Invoke ("callar", tiempo);
	}

	public void callar()
	{
		animator.SetBool("hola", false);
	}

	public void  mensajes (){
		nuve.SetActive(true);
		if (boolnamui) {
			mensaje.text = palabraNamui;
		} else {
			mensaje.text = palabraEspanol;
		}
			
			
	}

	public void cambiarLenguaje()
	{
		if (boolnamui) {
			boolnamui = false;
			lenguaje.text="Namui Wam";
		} else {
			boolnamui = true;
			lenguaje.text="Español";
		}
		Invoke ("mensajes",0);
	}


	public void ocultar(){	
		nuve.SetActive(false);



	}

}
