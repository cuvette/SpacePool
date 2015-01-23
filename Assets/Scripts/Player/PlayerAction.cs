using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAction : MonoBehaviour {

	public float distance = 1000f;

	public float powerByFrame = 1f;
	public string fire = "Fire3";
	public float powerMult = 1;
	public AudioClip curseurUpClip;
	public AudioClip curseurConstantClip;
	public AudioClip lancerClip;

	private bool isCharge;
	private bool releaseButton;
	private float power;
	private AudioSource audio;
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		isCharge = false;
		power = 0;
		releaseButton = true;
		audio = GetComponent<AudioSource>();
		canvas = GameObject.FindGameObjectWithTag("UI").GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		fireOnPlanet();

		if (Input.GetAxis (fire)==0)
			releaseButton = true;
	}

	void fireOnPlanet(){

		if (Input.GetAxis (fire)>0 && releaseButton) {
			isCharge = true;
			if(power<100)
			{	
				if(!audio.isPlaying || audio.clip != curseurUpClip )
				{
					audio.clip = curseurUpClip;
					audio.loop = false;
					audio.Play();
				}
				power += powerByFrame;
				canvas.scaleFactor += powerByFrame*0.1f;
			}
			else
			{
				if(!audio.isPlaying){
					audio.clip = curseurConstantClip;
					audio.loop = true;
					audio.Play();
				}
			}
		}
		if ((isCharge && Input.GetAxis (fire)==0)) {
			isCharge = false;
			audio.Stop();
			RaycastHit[] hits = Physics.RaycastAll (transform.position, transform.forward, distance);
			float minDist = 1000f;
			int target = 0;
			if(hits.Length > 0)
			{
				for (int i=hits.Length-1;i>=0;i--) {
					RaycastHit hit = hits[i];
					if (hit.collider.gameObject != null && hit.collider.gameObject.tag == "Planet") {
						float d = Vector3.Distance(transform.position,hit.collider.gameObject.transform.position);
						if(d < minDist)
						{
							minDist = d;
							target = i;
						}
					}
				}
				if(hits[target].collider.gameObject.tag =="Planet"){
					hits[target].collider.rigidbody.AddForceAtPosition (transform.forward * power * powerMult * (1/Time.timeScale), hits[target].point);
					audio.clip = lancerClip;
					audio.loop = false;
					audio.Play();
				}
			}
			canvas.scaleFactor = 1;
			power = 0;

			releaseButton = false;
		}
	}
}
