using UnityEngine;
using System.Collections;

public class ReversalSphereCollider : MonoBehaviour 
{
	public GameObject borderland;

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag != "Player")
		{
			GameObject o = Instantiate(borderland, other.gameObject.transform.position, Quaternion.identity) as GameObject;
			SoundPitcher sp = o.GetComponent<SoundPitcher>();
			sp.SelectAudioClip();
			o.audio.Play();
			o.particleSystem.Play();
			Destroy(o,2f);
			other.rigidbody.velocity = Vector3.Reflect(other.rigidbody.velocity, (transform.position-other.transform.position).normalized);
		}
	}
}
