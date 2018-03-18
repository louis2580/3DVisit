using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire_End : MonoBehaviour {

	public bool respect = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "magicWand" && respect) {
			Debug.Log ("aaaah c'est gagné!");

		}

	}


}
