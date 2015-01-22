using UnityEngine;
using System.Collections;

public class TimeStop : MonoBehaviour {

	private Vector3 velocity;
	private bool sleep;

	void Awake()
	{
		velocity = Vector3.zero;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(!sleep)
			{
				sleep = true;
				velocity = rigidbody.velocity;
				rigidbody.Sleep();
				rigidbody.isKinematic = true;
			}
			else
			{
				sleep = false;
				rigidbody.isKinematic = false;
				rigidbody.velocity = velocity;
			}
		}
	}
}
