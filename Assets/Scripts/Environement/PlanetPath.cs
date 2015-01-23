using UnityEngine;
using System.Collections;

public class PlanetPath : MonoBehaviour {

	private LineRenderer path;
	public float arrowLong = 1f;
	public float arrowWidth = 1;

	// Use this for initialization
	void Start () {
		path = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//linerenderer child planet (pour etre en relative de la planete
		if(Time.timeScale < 1)
		{
			path.SetVertexCount (2);
			path.SetWidth(arrowWidth, arrowWidth);
			path.SetPosition(0,transform.position);
			path.SetPosition (1, (transform.position + rigidbody.velocity.normalized * arrowLong));
	//		path.SetPosition (1, (rigidbody.velocity.normalized - transform.position));
		}
		else
		{
			path.SetVertexCount(0);
		}
	}
}
