using UnityEngine;
using System.Collections;

public class Nebula : MonoBehaviour {

	public float nebulaEffect = 5f;
	public AudioClip nebulaSound	;

	private AudioSource audio;

	void Awake()
	{
		audio = gameObject.GetComponent<AudioSource>();
		audio.clip = nebulaSound;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			audio.Play();
			other.rigidbody.velocity = other.rigidbody.velocity / nebulaEffect;
		}
	}
}
