using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarpoolTitle : MonoBehaviour {

	private int pageTuto;
	private Image[] listTuto;
	private Canvas titleCanvas;
	private Canvas tutoCanvas;

	private bool playerPushButton;


	// Use this for initialization
	void Start () {
		titleCanvas = GameObject.FindGameObjectWithTag ("Title").GetComponent<Canvas>();
		tutoCanvas = GameObject.FindGameObjectWithTag ("Tuto").GetComponent<Canvas>();

		tutoCanvas.enabled = false;

		playerPushButton = false;

		pageTuto = 0;
		listTuto = new Image[4];
		listTuto = tutoCanvas.GetComponentsInChildren<Image> ();

		for (int i=0; i<listTuto.Length; i++) {
			listTuto[i].enabled = false;
				}
	}
	
	// Update is called once per frame
	void Update () {
		//si start ou A
		//afficher tuto

		if (Input.GetButtonUp ("Cancel") || Input.GetButtonUp ("Fire1"))
						playerPushButton = false;

		if (!playerPushButton && (Input.GetButtonDown ("Cancel") || Input.GetButtonDown ("Fire1"))) {

			playerPushButton = true;

			titleCanvas.enabled = false;
			tutoCanvas.enabled = true;
			//affiche les tuto
			if (pageTuto < listTuto.Length){
				
				listTuto[pageTuto].enabled = true;
				if (pageTuto > 1)
					listTuto [pageTuto - 1].enabled = false;
				pageTuto++;
			}
			else 
			{
				Application.LoadLevel("main");
			}
		}
	}
}
