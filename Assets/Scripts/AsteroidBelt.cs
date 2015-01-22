using UnityEngine;
using System.Collections;

public class AsteroidBelt : MonoBehaviour {

	private SoundPitcher s;
	private AudioSource audio;

	void Awake()
	{
		s = GetComponent<SoundPitcher>();
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Planet")
		{
			ScoreDisplayer.addScore(ScoreDisplayer.asteroidCollision);
			audio.Stop ();
			s.SelectAudioClip();
			audio.Play();
		}
	}
}
