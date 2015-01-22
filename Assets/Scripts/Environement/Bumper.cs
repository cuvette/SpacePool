using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour 
{
	public float bumperEffect = 1.5f;
	private SoundPitcher soundPitcher;
	private AudioSource audio;

	void Awake()
	{
		soundPitcher = GetComponent<SoundPitcher>();
		audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Planet")
		{
			audio.Stop();
			soundPitcher.SelectAudioClip();
			audio.Play();
			other.rigidbody.velocity = other.rigidbody.velocity * bumperEffect;
			ScoreDisplayer.addScore(ScoreDisplayer.bumperCollision);
		}
	}
}
