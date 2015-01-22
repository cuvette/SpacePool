using UnityEngine;
using System.Collections;

public class PlanetPath : MonoBehaviour {

	private LineRenderer path;

	// Use this for initialization
	void Start () {
		path = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//linerenderer child planet (pour etre en relative de la planete
		path.SetVertexCount (2);
		path.SetPosition(0,transform.position);
		path.SetPosition (1, (transform.position + rigidbody.velocity));
//		path.SetPosition (1, (rigidbody.velocity.normalized - transform.position));
		
	}
}
