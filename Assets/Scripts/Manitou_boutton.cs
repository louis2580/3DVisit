using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manitou_boutton : MonoBehaviour {

	public GameObject lightDoor;
	private Light lightDoorComponent;

	public bouton bout1;
	public bouton bout2;
	public bouton bout3;
	public bouton bout4;

	public bool RFirst = false;
	public bool JSecond = false;
	public bool BThird = false;
	public bool VLast = false;

	public int count = 0 ;


	public BigBoss big;
	void Start() {
		lightDoorComponent = lightDoor.GetComponent<Light> ();
	}

   
	public bool jeux=true;

	public void getInfo(int bouton){
		if (jeux) {
			RFirst = RFirst || bouton == 1;
			JSecond = JSecond || (bouton == 2 && RFirst);
			BThird = BThird || (bouton == 3 && JSecond);
			VLast = VLast || (bouton == 4 && BThird);


			if (count == 4) {
				if (VLast) {
					lightDoorComponent.color = Color.green;
					big.OneDown ();
				} else {

					jeux = false;
					RFirst = false;
					JSecond = RFirst;
					BThird = false;
					count = 0;
					float b = 0;

					StartCoroutine (Reset ());

				}
			}
		}
	}

	IEnumerator Reset(){

		yield return new WaitForSecondsRealtime (2);
		bout1.reset ();
		bout2.reset ();
		bout3.reset ();
		bout4.reset ();
		jeux = true;

	}


}
