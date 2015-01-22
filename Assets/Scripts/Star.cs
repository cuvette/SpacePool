using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public float force = 100f;

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			Vector3 thisPosition = transform.position;
			Vector3 otherPosition = other.gameObject.transform.position;
			other.rigidbody.constantForce.force = (thisPosition - otherPosition)/Vector3.Distance(thisPosition,otherPosition) * force;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			other.rigidbody.constantForce.force = Vector3.zero;
		}
	}
}
