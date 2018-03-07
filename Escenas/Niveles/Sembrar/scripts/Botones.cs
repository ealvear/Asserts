using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;	

public class Botones : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public bool	pulsado;

	// Use this for initialization

	public void OnPointerDown(PointerEventData eventData){
		pulsado = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		pulsado = false;
	}



}
