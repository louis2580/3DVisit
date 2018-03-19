using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire_End : MonoBehaviour {

	public bool respect = false;
	private bool win = false;
	private bool winSoundPlayed = false;
	private bool loseSoundPlayed = true;

	public GameObject light;
	private Light lightComponent;

	public GameObject winSound;
	private AudioSource winSoundComponent;

	public GameObject loseSound;
	private AudioSource loseSoundComponent;

	private float timeBeforeLostMusic = 0;

	// Use this for initialization
	void Start () {
		lightComponent = light.GetComponent<Light> ();
		winSoundComponent = winSound.GetComponent<AudioSource> ();
		loseSoundComponent = loseSound.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (!win) {
			if (respect) {
				inGame ();
			} else {
				gameLost ();
			}
		}
	}

	void inGame() {
		timeBeforeLostMusic += Time.deltaTime;
		loseSoundPlayed = false;
		lightComponent.color = Color.yellow;
	}

	void gameLost() {
		if (!loseSoundPlayed && timeBeforeLostMusic > 0.2) {
			loseSoundPlayed = true;
			loseSoundComponent.time = (float) 0.7;
			loseSoundComponent.Play ();
			timeBeforeLostMusic = 0;
			lightComponent.color = Color.red;
		}
	}

	void gameWon() {
		if (!winSoundPlayed) {
			winSoundPlayed = true;
			winSoundComponent.time = (float) 0.7;
			winSoundComponent.Play ();
			lightComponent.color = Color.green;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "magicWand" && respect) {
			win = true;
			gameWon ();
			Debug.Log ("aaaah c'est gagné!");
		}
	}
}