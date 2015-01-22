using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public int overloadValue = 5;
	public float volumeBlackHoleIn = 0.5f;
	public AudioClip blackHoleClip;

	private GameObject gameController;
	private Slider overloadVisual;
	private AudioSource audio;
	private string playerScoreKey = "PlayerScore";
	private int scoreValue;

	void Awake () {
		audio = GetComponent<AudioSource>();

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		overloadVisual = gameController.GetComponentInChildren<Slider> ();
	}

	void Update()
	{
		if(!audio.isPlaying)
		{
			audio.volume = 1;
			audio.loop = true;
			audio.clip = blackHoleClip;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			audio.loop = false;
			audio.volume = volumeBlackHoleIn;
			audio.Play();
			overloadVisual.value += overloadValue;
			if(overloadVisual.value>=100){
				PlayerPrefs.SetInt(playerScoreKey, gameController.GetComponentInChildren<ScoreDisplayer> ().getScore());
				Application.LoadLevel("gameOver");
			}
			Destroy(other.gameObject);
		}
	}
}
