using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour {
	private bool muerto;
	private Rigidbody2D rb2d;
	public float fuerzaVuelo= 200f; 
	private Animator anim;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (muerto)
			return;


			if(Input.GetMouseButtonDown(0)){
				rb2d.velocity = Vector2.zero;
			rb2d.AddForce (Vector2.up*fuerzaVuelo);		
			anim.SetTrigger ("Aleteo");
		}


	}

	private void OnCollisionEnter2D(Collision2D collision){
		anim.SetTrigger ("Muerto");
		muerto = true;
	}

}
