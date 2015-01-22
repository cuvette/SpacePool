using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseCanvas;
	public Canvas tutoCanvas;
	public Canvas creditCanvas;
	public Text textArrowPosition;
	public float secondsBeforeTitle;

	private GameObject player;

	private int arrowPosition;
	private bool playerPushVerticalButton;
	private bool playerPushFireButton;
	private bool playerPushCancelButton;
	private bool tutoActivated;
	private int pageTuto;

	private MonoBehaviour mouseOrbit;
	private PlayerAction playerAction;
	private TimeControl timeControl;

	private Image[] listTuto;
	private float timeBeforeReset;

	// Use this for initialization
	void Start () {
		pauseCanvas.enabled = false;
		creditCanvas.enabled = false;
		tutoCanvas.enabled = false;
		arrowPosition = 0;
		playerPushVerticalButton = false;
		playerPushFireButton = false;

		player = GameObject.FindGameObjectWithTag("MainCamera");

		mouseOrbit = player.GetComponent("MouseOrbit") as MonoBehaviour;
		playerAction = player.GetComponent<PlayerAction> ();
		timeControl = player.GetComponent<TimeControl> ();

		pageTuto = 0;
		listTuto = new Image[4];
		listTuto = tutoCanvas.GetComponentsInChildren<Image>();
		for (int i = 0; i<listTuto.Length; i++)
						listTuto [i].enabled = false;

		tutoActivated = false;

		timeBeforeReset = Time.time + secondsBeforeTitle;
	}
	
	// Update is called once per frame
	void Update () {

		//relance si pas d'activité
		if (timeBeforeReset < Time.time)
			Application.LoadLevel("title");

		if (Input.anyKeyDown) 
			timeBeforeReset = Time.time + secondsBeforeTitle;

		//position de la flèche
		textArrowPosition.rectTransform.anchoredPosition = new Vector3(-200,arrowPosition*(-70),0);

		//mouvement de la flèche
		if (!playerPushVerticalButton) {
			if (Input.GetAxis ("arrowUpDown") > 0 && arrowPosition > 0) {
					arrowPosition--;
				playerPushVerticalButton = true;
			}

			if (Input.GetAxis ("arrowUpDown") < 0 && arrowPosition < 3) {
					arrowPosition++;
				playerPushVerticalButton = true;
			}
		}

		if(Input.GetAxis ("arrowUpDown") == 0) {
			playerPushVerticalButton = false;
				}

		//desactive controle si pauseactive
		if (pauseCanvas.enabled == true || tutoCanvas.enabled == true || tutoCanvas.enabled == true) {
			mouseOrbit.enabled = false;
			playerAction.enabled = false;
			timeControl.enabled = false;
				} else {
			mouseOrbit.enabled = true;
			playerAction.enabled = true;
			timeControl.enabled = true;
				}

		//affichage pause
		if (!playerPushCancelButton && Input.GetButtonDown("Cancel"))
		{
			arrowPosition = 0;
			if(pauseCanvas.enabled == false && creditCanvas.enabled == false && tutoCanvas.enabled == false)
				pauseCanvas.enabled = true;
			else if(pauseCanvas.enabled == true && creditCanvas.enabled == false && tutoCanvas.enabled == false)
				pauseCanvas.enabled = false;
			else if(pauseCanvas.enabled == false && creditCanvas.enabled == true && tutoCanvas.enabled == false){
				pauseCanvas.enabled = true;
				creditCanvas.enabled = false;
			}
			else if(pauseCanvas.enabled == false && creditCanvas.enabled == false && tutoCanvas.enabled == true){
				pauseCanvas.enabled = true;
				tutoCanvas.enabled = false;
				pageTuto = 0;
				tutoActivated = false;
 
				for(int i=0;i<listTuto.Length;i++){
					listTuto[i].enabled = false;
				}
			}

			playerPushCancelButton = true;
		}

		if (Input.GetButtonUp("Cancel"))
		{
			playerPushCancelButton = false;
		}

		//valider menu
		if (Input.GetButtonUp ("Fire1")) {
			playerPushFireButton = false;
		}

		if (!playerPushFireButton && Input.GetButtonDown ("Fire1") && (pauseCanvas.enabled == true || tutoCanvas.enabled == true)) {

			Debug.Log(tutoCanvas.enabled);

					if (!tutoActivated) {
							playerPushFireButton = true;
							pauseCanvas.enabled = false;

							switch (arrowPosition) {
							case 1:
									Application.LoadLevel ("main");
									break;
							case 2: 
									tutoCanvas.enabled = true;
									tutoActivated = true;
									break; 
							case 3: 
									creditCanvas.enabled = true;
									break;
							}
					}
				if(tutoActivated){

					
				
					if (pageTuto < listTuto.Length){

					listTuto[pageTuto].enabled = true;
					if (pageTuto > 1)
						listTuto [pageTuto - 1].enabled = false;
					pageTuto++;
				}
					else{
						pageTuto = 0;
						tutoActivated = false;
						listTuto[3].enabled = false;
						tutoCanvas.enabled = false;
					pauseCanvas.enabled = true;
					}
				}
		}
			

			/*if (!playerPushFireButton && Input.GetButtonDown ("Fire1") && tutoCanvas.enabled == true) {
					tutoCanvas.enabled = false;
					pauseCanvas.enabled = true;
			}*/

			if (!playerPushFireButton && Input.GetButtonDown ("Fire1") && creditCanvas.enabled == true) {
					creditCanvas.enabled = false;
					pauseCanvas.enabled = true;
			}


	}

	//void displayTuto(string origin){



		/*if (!playerPushFireButton && Input.GetButtonDown ("Fire1")) {
						Debug.Log ("flag1");

						if (pageTuto > 1)
								listTuto [pageTuto - 1].enabled = false;
			
						listTuto [pageTuto].enabled = true;

						if (pageTuto < 4) {
								pageTuto++;
						} else {
								listTuto [3].enabled = false;
								pageTuto = 0;
								if (origin == "pause") {
										pauseCanvas.enabled = true;
								}
						}
				}*/

	}

