using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuambianoCaminaSolo : MonoBehaviour {

	//-------------------------------------------------//
	public float fuerzaSalto = 100f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	private bool dobleSalto = false;
	private bool corriendo = false;
	public float velocidad = 1f;
	public LayerMask mascaraSuelo;
	private Animator animator;
	private AudioSource audio;
	public TextMesh marcador;

	float  n=0;
	int pun=0;
	//-------------------------------------------------//
	void Awake(){
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
		audio=GetComponent<AudioSource>();

	}

	void FixedUpdate(){
		if(corriendo){

			//Debug.Log (" entrooo ="+ GetComponent<Rigidbody2D>().velocity.x);
			if (GetComponent<Rigidbody2D>().velocity.x==0 && GetComponent<Rigidbody2D>().velocity.y==0) {
				GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x ,GetComponent<Transform> ().position.y - n,GetComponent<Transform> ().position.z); 
			}

			GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
			n = 0.35f;

		}
		animator.SetFloat("velMovimiento", GetComponent<Rigidbody2D>().velocity.x);
		animator.SetFloat("VelVertical", GetComponent<Rigidbody2D>().velocity.y);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool("EnSuelo", enSuelo);
		if(enSuelo){
			dobleSalto = false;
		}
	}

	// Update is called once per frame
	void Update () {
		
			aumentarVelocidad ();

		if(Input.GetMouseButtonDown(0)){
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(enSuelo || !dobleSalto){
					audio.Play();
					//GetComponent<AudioSource>().Play();

					GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
					//GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));

					if(!dobleSalto && !enSuelo){
						dobleSalto = true;
					}
				}
			}else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
			}
		}
	}

	public void aumentarVelocidad () {
		bool ban2=int.TryParse(marcador.text, out pun);
		if( pun>=10){velocidad=9f;}
		if( pun>=50){velocidad=11f;}
		if( pun>=100){velocidad=15f;}
	}


}
