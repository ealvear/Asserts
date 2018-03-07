using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaObejtivo : MonoBehaviour {
	public Transform trom;
	public Transform to;




	// Use this for initialization
	void OnDrawGizmosSelected(){
		if(trom != null && to != null){
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine (trom.position, to.position);
			Gizmos.DrawSphere (trom.position,0.15f);
			Gizmos.DrawSphere (to.position,0.3f);

		}
	}
}
