using UnityEngine;
using System.Collections;

public class WormHole1 : MonoBehaviour 
{
	public GameObject toInstanciate;
	public WormHole1 outWormHole;

	private int count = 0;
	private bool canTP = true;


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			count++;
			if(canTP)
			{
				outWormHole.canTP = false;
				CreateNewPlanet(other.rigidbody.velocity);
				other.gameObject.SetActive(false);
				GameObject.Destroy(other.gameObject);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		count--;
		if(count == 0)
		{
			canTP = true;
		}
	}

	void CreateNewPlanet(Vector3 velocity)
	{
		Vector3 pos = -gameObject.transform.position;
		Vector3 p1 = new Vector3(pos.x, pos.y, pos.z);
//		Vector3 p2 = new Vector3(pos.x - 1, pos.y - 1, pos.z - 1);

		GameObject o1 = Instantiate(toInstanciate, p1, Quaternion.identity) as GameObject;
		o1.rigidbody.velocity = velocity;
//		GameObject o2 = Instantiate(toInstanciate, p2, Quaternion.identity) as GameObject;
//		o2.rigidbody.velocity = -velocity;
	}
}
