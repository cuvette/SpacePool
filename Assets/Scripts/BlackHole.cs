using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public int overloadValue = 5;
	public float volumeBlackHoleIn = 0.5f;
	public AudioClip blackHoleClip;

	private Slider overloadVisual;
	private AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource>();
		overloadVisual = GameObject.FindGameObjectWithTag ("GameController").GetComponentInChildren<Slider> ();
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
				Application.LoadLevel("gameOver");
			}
			Destroy(other.gameObject);
		}
	}
}
