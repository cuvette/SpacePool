using UnityEngine;
using System.Collections;

public class WormHole : MonoBehaviour 
{
	public GameObject toInstanciate;
	public float speedMult = 5f;
	public float timeToRestart = 0.5f;
//	public WormHole outWormHole;
	private float timer = 0;

//	private int count = 0;
//	private bool canTP = true;
	void Update()
	{
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
//			count++;
//			if(canTP)
//			{
//				outWormHole.canTP = false;
			if(timer >= timeToRestart)
			{
				CreateNewPlanet(other.rigidbody.velocity);
				//other.gameObject.SetActive(false);
				GameObject.Destroy(other.gameObject);
				timer = 0;
			}
		}
	}

//	void OnTriggerExit(Collider other)
//	{
//		count--;
//		if(count == 0)
//		{
//			canTP = true;
//		}
//	}

	void CreateNewPlanet(Vector3 velocity)
	{
		Vector3 pos = -gameObject.transform.position;
		Vector3 p1 = new Vector3(pos.x, pos.y, pos.z);
		Vector3 p2 = new Vector3(pos.x -1, pos.y - 1, pos.z - 1);

		GameObject o1 = OverlapInstantiator.OverInstantiate(toInstanciate, p1) as GameObject;
		o1.rigidbody.velocity = velocity*speedMult;
		GameObject o2 = OverlapInstantiator.OverInstantiate(toInstanciate, p2) as GameObject;
		o2.rigidbody.velocity = -velocity*speedMult;

	}
}
