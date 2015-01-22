using UnityEngine;
using System.Collections;

public class Starter : MonoBehaviour 
{

	public GameObject basePlanet;
	public GameObject sun;
	public float explosionForce = 1000f;
	public float explosionRadius = 1f;
	public float sphereRadius = 10;
	public int planetCount = 100;
	public float timeToExplode = 1f;
	public float timeToRenderPlanets = 2f;
	public float timeToRenderSun = 3f;

	private ParticleSystem bigBang;
	private GameObject[] planets;
	private float timer = 0;
	private bool sunDone = false;
	private bool planetRenderDone = false;
	private bool explosionDone = false;
	private bool finished = false;
	private AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource>();
		planets = new GameObject[planetCount];
		bigBang = GetComponentInChildren<ParticleSystem>();
	}

	void Update()
	{
		if(!finished)
		{
			timer += Time.deltaTime;
			

			if(timer >= timeToExplode && ! explosionDone)
			{
				bigBang.Play();
				audio.Play();
				explosionDone = true;
			}
			if(timer >= timeToRenderSun && !sunDone)
			{
				Instantiate(sun, Vector3.zero, Quaternion.identity);
				sunDone = true;
			}
			if(timer >= timeToRenderPlanets && !planetRenderDone)
			{
				StartCoroutine(Generation());
				planetRenderDone = true;
			}
			if(explosionDone && sunDone && planetRenderDone)
			{
				finished = true;
			}
		}
		
	}

	IEnumerator Generation()
	{
		for(int i=0; i< planetCount; i++)
		{
			Vector3 r = Random.insideUnitSphere * sphereRadius;
			GameObject o = Instantiate(basePlanet, r, Quaternion.identity) as GameObject;
			o.rigidbody.AddExplosionForce(explosionForce, Random.insideUnitSphere * sphereRadius, explosionRadius);
			yield return null;
		}
	}

}
