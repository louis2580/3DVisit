using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public float angle;

	public Vector3 gond;



	// Use this for initialization
	void Start () {
		gond = this.GetComponentInChildren<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {

		//this.transform.RotateAround (gond, Vector3.right, angle);
		this.transform.rotation= Quaternion.Euler(new Vector3(-90,angle,180));

	}
}
