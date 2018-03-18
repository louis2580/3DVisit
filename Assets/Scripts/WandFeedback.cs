using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandFeedback : MonoBehaviour {

	public bool isInIt = false , isInGame = false;
	public SteamVR_ControllerManager stvr;
	float t;
	public wire_End jeux;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isInGame && !isInIt)
		{
			t += Time.deltaTime; 
			stvr.Vibrate ();
			if (t > 1) {
				isInIt = false;
				isInGame = false;
				t = 0;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "magicWand") {
			isInIt = true;
			isInGame = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "magicWand") {
			isInIt = false;
			jeux.respect=false;
		}
	}
}
