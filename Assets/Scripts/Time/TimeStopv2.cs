using UnityEngine;
using System.Collections;

public class TimeStopv2 : MonoBehaviour {
	
	private bool sleep;

	void Awake()
	{
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(!sleep)
			{
				sleep = true;
				Time.timeScale = 0f;
			}
			else
			{
				sleep = false;
				Time.timeScale = 1f;
			}
		}
	}
}
