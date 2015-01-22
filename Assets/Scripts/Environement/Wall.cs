using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour 
{
	public Vector3 normal = Vector3.zero;

	private static bool passed = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
		{
			if(passed == false)
			{
				other.collider.gameObject.transform.position = Vector3.Reflect(other.collider.gameObject.transform.position,normal);
				passed = true;
			}
			else
			{
				passed = false;
			}
		}
	}
}
