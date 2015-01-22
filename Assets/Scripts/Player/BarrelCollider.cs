using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrelCollider : MonoBehaviour {

	public float speedPlanet = 5f;

	private List<GameObject> planets;

	void Awake()
	{
		planets = new List<GameObject>();
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Planet")
		{
			planets.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			planets.Remove(other.gameObject);
		}
	}

	public void Fire()
	{
		for(int i=0; i<planets.Count; i++)
		{
			if(planets[i]==null) // If object was destroyed
				continue;

			Camera mainCamera = transform.GetComponentInParent<Camera> ();

			float power = 100 * speedPlanet ;// Vector3.Distance(mainCamera.transform.position,planets[i].transform.position);

			if (Time.timeScale < 1)
			{
				planets[i].rigidbody.AddForce(transform.forward * power * 1/Time.timeScale);
			} 
			else
			{
				planets[i].rigidbody.AddForce(transform.forward * power);
			}
		}
	}
}
