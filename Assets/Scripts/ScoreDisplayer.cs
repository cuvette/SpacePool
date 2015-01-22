using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour {
	public Text textScore;

	private int score = 0;
	private Text affichageScore;
	static private ScoreDisplayer instance;

	public const int planetCollision = 5000;
	public const int planetFusion = 10000;
	public const int starCreation = 50000;
	public const int wormholeSucking = 75000;
	public const int bumperCollision = 7000;
	public const int asteroidCollision = 2000;


	// Use this for initialization
	void Start () {
		instance = this;

		foreach( Text text in GetComponentsInChildren<Text>() ){
			if(text == textScore){ 
				affichageScore = text; 
			}
		}
		instance.affichageScore.text = "0";
	}

	// Update is called once per frame
	void Update(){
		int oldScore = int.Parse(instance.affichageScore.text);
		int newScore = (oldScore + score + 1) / 2;
		instance.affichageScore.text = newScore.ToString ();

	}
	public static void addScore(int points){
		instance.score += points;
	}

	public int getScore(){
		return int.Parse(instance.affichageScore.text);
	}
}
