using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour {
	public Transform t;
	public float zoom=0f;
	// Use this for initialization
	void Start () {
		t = GetComponent<Transform>();
		GameObject objeto = GameObject.FindGameObjectWithTag ("Misak");
	//	Debug.Log ("este es"+objeto.name);


	}
		
	// Update is called once per frame
	public void vers(){
		t.localScale=new Vector3 (t.localScale.x+zoom,t.localScale.y+zoom,t.localScale.z+zoom);
		Debug.Log ("este es"+this.t.position.x);
	}
}
