using UnityEngine;
using System.Collections;

public class TestInstantiation : MonoBehaviour {

	public GameObject o;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			OverlapInstantiator.OverInstantiate(o, Vector3.zero);
		}
	}
}
