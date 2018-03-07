using UnityEngine;
using System.Collections;

public class Destruir : MonoBehaviour {

	// Use this for initialization
	public float tiempoVida;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Destroy (gameObject ,tiempoVida);
	}
}
