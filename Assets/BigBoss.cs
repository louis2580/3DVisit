using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour {


	public bool finish=false;

	public int count = 0;

	private float angle=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (finish && angle<160) {
			this.transform.rotation = Quaternion
				.Euler (new Vector3 (-90, angle, 0));

			angle += 1;

		}
	}

	public void OneDown(){
		count++;

		if (count == 3)
			finish = true;

	}


}
