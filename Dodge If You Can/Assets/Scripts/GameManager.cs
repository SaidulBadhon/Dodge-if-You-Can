using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject mobileControler;
	public Camera mainCamera;
	public GUISkin mySkin;
	public bool paused = false;
	public float playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		mobileControler = GameObject.FindGameObjectWithTag ("MobileControler");
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){
			playerHealth = player.GetComponent<PlayerHealth> ().curHealth;

		}

		if (playerHealth == 0) {
			GetComponent<PauseMenu>().WindowName = "GameOver";
			GetComponent<PauseMenu>().paused = true;
		}



//		if (GameObject.FindGameObjectWithTag ("Enemy") != null) {
//			return;
//		} else {
//			GetComponent<PauseMenu> ().WindowName = "GameOver";
//			GetComponent<PauseMenu> ().paused = true;
//		}
	}
	public void SaveScore(bool save){
		if (save == true) {
			GetComponent<SaveGame> ().SaveScore (GetComponent<GameCurrencyManager>().score);
			save = false;
		}
	}
	void OnGUI(){
		GUI.skin = mySkin;
		if (!paused) {
//			for (int i = 0; i < mobileControler.transform.GetChildCount (); i++) {
////				if (mobileControler.GetChild (i).image != null)
//				mobileControler.transform.GetChild (i).gameObject.SetActive(true);
//			}

//			mobileControler.gameObject.SetActive (true);

			GetComponent<GameCurrencyManager> ().ScoreGUI ();
			player.GetComponent<PlayerHealth> ().HealthGUI ();
		} else {
//			mobileControler.gameObject.SetActive (false);
		}
	}
}
