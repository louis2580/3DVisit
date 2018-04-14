using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour {

	public BigBoss big;

	public GameObject lightDoor;
	private Light lightDoorComponent;
	public bool win;

	// Use this for initialization
	void Start () {
		lightDoorComponent = lightDoor.GetComponent<Light> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "balle") {
			win = true;
			lightDoorComponent.color = Color.green;
			big.OneDown ();
		}
	}
}
