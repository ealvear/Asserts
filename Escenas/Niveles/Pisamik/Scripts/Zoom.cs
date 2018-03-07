using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	[SerializeField] float velocidadDeZoom =0.1f;
	[SerializeField] Vector2 Limites;
	Camera cam;
	public Transform t;

	void Start(){


	}

	void Update(){
		if (Input.touchCount == 2) {
			Touch t0 = Input.GetTouch (0);
			Touch t1 = Input.GetTouch (1);

			Vector2 t0Cambio = t0.position - t0.deltaPosition;
			Vector2 t1Cambio = t1.position - t1.deltaPosition;

			float magnitudToquesAnteriores = t0Cambio.magnitude - t1Cambio.magnitude;
			float magnitudToque = t0.position.magnitude - t1.position.magnitude;

			float diferencia = magnitudToquesAnteriores - magnitudToque;




			t.localScale += new Vector3 (t.localScale.x+(diferencia * velocidadDeZoom),t.localScale.y+(diferencia * velocidadDeZoom),t.localScale.z+(diferencia * velocidadDeZoom));

			//t.localScale = Mathf.Clamp (t.localScale.x, Limites.x,Limites.y);





				}



				}
				}
