using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouton : MonoBehaviour {

	public Manitou_boutton telephone_rouge;

	public int qui_suis_je=0;

	public bool pressed=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) {
		if (!pressed) {
			pressed = true;
			telephone_rouge.count++;
			telephone_rouge.getInfo (qui_suis_je);

			this.transform.localPosition = new Vector3 (0, (float)-0.2, 0);
		}
	}

	public void reset()
	{
		pressed = !pressed;
		this.transform.localPosition = new Vector3 (0, (float)-1, 0);
	}
}
