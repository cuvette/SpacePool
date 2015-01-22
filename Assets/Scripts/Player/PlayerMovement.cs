using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");

		Vector3 direction = (transform.forward * v) + (transform.right * h);

		transform.Translate(/*transform.position + */(direction * speed * 0.02f));
	}
}
