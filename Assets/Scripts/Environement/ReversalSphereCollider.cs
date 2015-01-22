using UnityEngine;
using System.Collections;

public class ReversalSphereCollider : MonoBehaviour 
{


	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag != "Player")
		{
			other.rigidbody.velocity = Vector3.Reflect(other.rigidbody.velocity, (transform.position-other.transform.position).normalized);
		}
	}
}
