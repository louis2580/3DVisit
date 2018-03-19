using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire_Start : MonoBehaviour {
	
	public wire_End jeux;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "magicWand") {
			Debug.Log ("aaaah ca commence!");
			jeux.respect = true;
		}
	}
}