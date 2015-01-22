using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour 
{
	public int lvl;
	public float maxSpeed = 100f;

	public AudioClip collisionClip;
	public AudioClip limiteClip;

	public float bumperProb = 0f;
	public float wormHoleProb = 0f;
	public float blackHoleProb = 0f;
	public float starProb = 0f;
	public float nebulaProb = 0f;
	
	public int maxBumper = 5;
	public int maxWormHole = 5;
	public int maxBlackHole = 5;
	public int maxStar = 5;
	public int maxNebula = 5;

	private static int bumperCount = 0;
	private static int wormHoleCount = 0;
	private static int blackHoleCount = 0;
	private static int starCount = 0 ;
	private static int nebulaCount = 0;

	public GameObject nextPlanet;
	public GameObject bumper;
	public GameObject wormHole;
	public GameObject blackHole;
	public GameObject star;
	public GameObject nebula;

	private float[] cumProbaTab;
	private AudioSource audio;
	private ParticleSystem fx;

	void Awake()
	{
		fx = GetComponentInChildren<ParticleSystem>();
		cumProbaTab = new float[6];
		cumProbaTab[0] = bumperProb;
		cumProbaTab[1] = cumProbaTab[0] + wormHoleProb;
		cumProbaTab[2] = cumProbaTab[1] + blackHoleProb;
		cumProbaTab[3] = cumProbaTab[2] + starProb;
		cumProbaTab[4] = cumProbaTab[3] + nebulaProb;
		cumProbaTab[5] = 1 - cumProbaTab[4];
		audio = GetComponent<AudioSource>();
		audio.clip = collisionClip;
	}

	void Update()
	{
		rigidbody.velocity = Vector3.Min(rigidbody.velocity, Vector3.one * maxSpeed);
	}

	void OnCollisionEnter(Collision other)
	{
		audio.Stop();
		audio.Play();
		fx.Play();
		if(other.gameObject.tag == "Planet")
		{
			if(other.gameObject.GetComponent<Planet>().lvl == lvl)
			{
				if(rigidbody.velocity.magnitude > other.rigidbody.velocity.magnitude)
				{
					ScoreDisplayer.addScore(ScoreDisplayer.planetFusion);
					if(ChooseNextEntity())
					{
						GameObject.Destroy(gameObject);
						GameObject.Destroy(other.gameObject);
					}
				}
			}
			else
			{
				ScoreDisplayer.addScore(ScoreDisplayer.planetCollision/2);
			}
		}
		
	}

	bool ChooseNextEntity()
	{
		float rand = Random.value;
		if(rand <= cumProbaTab[0])
		{
			if(bumperCount >= maxBumper)
				return false;
			CreateBumper();
		}
		else if(rand <= cumProbaTab[1])
		{
			if(wormHoleCount >= maxWormHole)
				return false;
			CreateWormHole();
		}
		else if(rand <= cumProbaTab[2])
		{
			if(blackHoleCount >= maxBlackHole)
				return false;
			CreateBlackHole();
		}
		else if(rand <= cumProbaTab[3])
		{
			if(starCount >= maxStar)
				return false;
			CreateStar();
		}
		else if(rand <= cumProbaTab[4])
		{
			if(nebulaCount >= maxNebula)
				return false;
			CreateNebula();
		}
		else{
			CreatePlanet();
		}
		return true;
	}

	void CreateBumper()
	{
		OverlapInstantiator.OverInstantiate(bumper, transform.position);
		bumperCount++;
	}

	void CreateWormHole()
	{
		GameObject o1 = OverlapInstantiator.OverInstantiate(wormHole, transform.position) as GameObject;
//		GameObject o2 = OverlapInstantiator.OverInstantiate(wormHole, -transform.position) as GameObject;
		WormHole w1 = o1.GetComponent<WormHole>();
//		WormHole w2 = o1.GetComponent<WormHole>();
//		w1.outWormHole = w2;
//		w2.outWormHole = w1;
		wormHoleCount = wormHoleCount+1;
	}

	void CreateBlackHole()
	{
		OverlapInstantiator.OverInstantiate (blackHole, transform.position);
		blackHoleCount++;
	}

	void CreateStar()
	{
		ScoreDisplayer.addScore(ScoreDisplayer.starCreation);
		OverlapInstantiator.OverInstantiate(star, transform.position);
		starCount++;
	}

	void CreateNebula()
	{
		OverlapInstantiator.OverInstantiate(nebula, transform.position);
		nebulaCount++;
	}

	void CreatePlanet()
	{
		GameObject o = Instantiate(nextPlanet, transform.position,Quaternion.identity) as GameObject;
		o.rigidbody.velocity = rigidbody.velocity;
	}
}
