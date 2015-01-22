using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public string axisTime = "Fire2";
	public float slowScale = .05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis (axisTime) > 0) {
			Time.timeScale = slowScale;
		} else {
			Time.timeScale = 1;
		}
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}
}
