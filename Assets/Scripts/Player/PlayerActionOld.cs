using UnityEngine;
using System.Collections;

public class PlayerActionOld : MonoBehaviour {

	public float distance = 1000f;

	public float powerByFrame = 2;
	public float powerMult = 1;
	public string fire = "Fire1";

	private bool isCharge;
	private bool releaseButton;
	private float power;

	// Use this for initialization
	void Start () {
		isCharge = false;
		power = 0;
		releaseButton = true;
	}
	
	// Update is called once per frame
	void Update () {
		fireOnPlanet();

		if (Input.GetButtonUp (fire))
			releaseButton = true;
	}

	void fireOnPlanet(){

		if (Input.GetButton (fire) && releaseButton) {
				isCharge = true;
				power += powerByFrame;
		}
		if ((isCharge && Input.GetButtonUp (fire)) || power == 100f) {
			isCharge = false;

			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, distance)) {
					if (hit.collider.gameObject.tag == "Planet") {
							hit.collider.rigidbody.AddForceAtPosition (transform.forward * power * powerMult, hit.point);
					}
			}
			Debug.Log("power = "+power);
			power = 0;

			releaseButton = false;
		}
				
	}
}
