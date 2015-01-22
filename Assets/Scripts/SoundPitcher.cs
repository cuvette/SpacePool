using UnityEngine;
using System.Collections;

public class SoundPitcher : MonoBehaviour {

	public float range = 0.2f;
	public AudioClip[] audioClips;
	private AudioSource audio;
	private float randomPitch;
	// Use this for initialization
	void Awake () {
		audio = gameObject.GetComponent<AudioSource>();
		randomPitch = Random.Range(-range,range);
	}
	
	// Update is called once per frame
	void Update ()
	{
		audio.pitch = Mathf.Max(Time.timeScale, 0.1f) + randomPitch;
	}

	public void SelectAudioClip()
	{
		if(audioClips.Length > 0)
		{
			audio.clip = audioClips[(int)(Random.Range(0.1f,audioClips.Length-0.1f))];
			randomPitch = Random.Range(-range, range);
		}
	}
}
