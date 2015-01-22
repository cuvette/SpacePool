using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarpoolOver : MonoBehaviour {

	private float timeBeforeRestart;
	private Text textHighScore;
	private string playerScoreKey = "PlayerScore";
	private int playerScoreValue;
	private int[] highScore;
	
	public int nbHighScore = 10;
	
	// Use this for initialization
	void Start () {
		timeBeforeRestart = Time.time + 10f;
		//affichage de score
		playerScoreValue = PlayerPrefs.GetInt(playerScoreKey);
		
		textHighScore = GameObject.FindGameObjectWithTag("Title").GetComponentInChildren<Text> ();
		highScore = new int[nbHighScore];
		for(int i=0;i<nbHighScore;i++){
			highScore[i] = PlayerPrefs.GetInt(playerScoreKey+i.ToString(),0);
		}

		bool registerHighScore = false;
		//limité avec un bool
		for(int i=0;i<nbHighScore;i++){
			if(playerScoreValue>highScore[i] && !registerHighScore){
				for(int j=nbHighScore-2;j>=i;j--){
					if(j>0)
						highScore[j] = highScore[j-1];
				}
				highScore[i] = playerScoreValue;
				registerHighScore = true;
			}
		}
		
		textHighScore.text += "\nVotre score : " + playerScoreValue +"\n";
		
		for(int i = 0;i<nbHighScore;i++){
			textHighScore.text += (i+1).ToString()+". "+highScore[i]+"\n";
			PlayerPrefs.SetInt(playerScoreKey+i.ToString(),highScore[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBeforeRestart < Time.time)
			Application.LoadLevel ("title");
	}
}
