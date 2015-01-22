using UnityEngine;
using System.Collections;

public class StarpoolOver : MonoBehaviour {

	private float timeBeforeRestart;

	// Use this for initialization
	void Start () {
		timeBeforeRestart = Time.time + 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBeforeRestart < Time.time)
						Application.LoadLevel ("title");
	}
}
