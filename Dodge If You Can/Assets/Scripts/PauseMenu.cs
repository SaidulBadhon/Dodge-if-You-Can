using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects; //UnityStandardAssets.ImageEffects

public class PauseMenu : MonoBehaviour {

	public bool paused = false;

	public Texture2D menuButton;
	public Texture2D Logo;

	public Rect DifWindowRect = new Rect (0,0,0,0);

	public string WindowName = "Menu";
	private bool isMute;

	void Start () {
		WindowName = "Menu";
		isMute = false;
	}
	
	void Update () {
//		WindowName = "GameOver";
	
		GetComponent<GameManager> ().paused = paused; 

		if (isMute == true) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}

		DifWindowRect = new Rect ((Screen.width * .5f) - (275), (Screen.height * .5f) - (324 / 2), 550, 324);
//		DifWindowRect = new Rect ((Screen.width * .5f) - (225), (Screen.height * .5f) - (200), 450, 324);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}
		if (paused) {
			transform.GetComponent<GameManager> ().mainCamera.GetComponent<Blur> ().enabled = true;
			transform.GetComponent<GameManager> ().mobileControler.GetComponent<Canvas> ().enabled = false;
			Time.timeScale = 0;
		} else {
			transform.GetComponent<GameManager> ().mainCamera.GetComponent<Blur>().enabled = false;
			transform.GetComponent<GameManager> ().mobileControler.GetComponent<Canvas> ().enabled = true;
			Time.timeScale = 1;
		}

	}

	void OnPouse(){
	}

	void OnGUI(){
		GUI.skin = transform.GetComponent<GameManager> ().mySkin;
		if (!paused) {
			if (GUI.Button (new Rect ((Screen.width - 100), 0, 200, 200), menuButton, "Menu Button")) {
				paused = !paused;
			}
		}
		if (paused) {
			if (WindowName == "Menu") {
				DifWindowRect = GUI.Window (0, DifWindowRect, MainMenu, "", "My Window");
			} else if (WindowName == "Option") {
				DifWindowRect = GUI.Window (0, DifWindowRect, OptionWindow, "", "My Window");
			} else if (WindowName == "About") {
				DifWindowRect = GUI.Window (0, DifWindowRect, AboutWindow, "", "My Window");
			} else if (WindowName == "GameOver") {
				DifWindowRect = GUI.Window (0, DifWindowRect, GameOverWindow, "", "My Window");
			} 
		}
	}

	void MainMenu(int windowID) {
		GUI.Label (new Rect(0, 0, DifWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, DifWindowRect.width, 7),"", "Under Header");
		GUI.Label (new Rect(20, (50 * .5f) - 10, DifWindowRect.width, 30),"DodgE if you can !!", "Header Label");
		GUI.Label (new Rect(DifWindowRect.width - 45, 5, 40, 40), Logo, "Header Label");

		if (GUI.Button (new Rect(0, 60, DifWindowRect.width, 50), "Resume", "Menu Text")) {
			paused = !paused;
		}
		if (GUI.Button (new Rect(0, 60 + 50 + 3, DifWindowRect.width, 50), "Restart", "Menu Text")) {
			Application.LoadLevel (Application.loadedLevelName.ToString ());
		}
		if (GUI.Button (new Rect(0, 60 + 100 + 6, DifWindowRect.width, 50), "Option", "Menu Text")) {
			WindowName = "Option";
		}
		if (GUI.Button (new Rect(0, 60 + 150 + 9, DifWindowRect.width, 50), "About", "Menu Text")) {
			WindowName = "About";
		}
		if (GUI.Button (new Rect(0, 60 + 200 + 12, DifWindowRect.width, 50), "Quit", "Menu Text")) {
			GetComponent<GameManager> ().SaveScore (true);
			GameObject.FindGameObjectWithTag("Game Menager").GetComponent<AdsManager>().ShowDefaultAd();
			Application.LoadLevel (0);
		}
	}
	void OptionWindow(int windowID){
		GUI.Label (new Rect(0, 0, DifWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, DifWindowRect.width, 7),"", "Under Header");

		if (GUI.Button (new Rect (15, (50 * .5f) - 15, 30, 30), "", "Back Button"))
			WindowName = "Menu";

		GUI.Label (new Rect(50 + 20, (50 * .5f) - 12, DifWindowRect.width, 30),"Options", "Header Label");
		GUI.Label (new Rect(DifWindowRect.width - 45, 5, 40, 40), Logo, "Header Label");

		GUI.Label (new Rect (0, 60, DifWindowRect.width, 50), "Audio :", "Option Button");



		if (isMute == true) {
			GUI.Label (new Rect (150, 60, 100, 50), "OFF", "Option Button");
		} else if (isMute == false) {
			GUI.Label (new Rect (150, 60, 100, 50), "On", "Option Button");
		}
		isMute = GUI.Toggle (new Rect (505, 65, 40, 40), isMute, "", "My Toggle");

	}

	void AboutWindow(int windowID){
		GUI.Label (new Rect(0, 0, DifWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, DifWindowRect.width, 7),"", "Under Header");
		if (GUI.Button (new Rect (20, (50 * .5f) - 15, 30, 30), "", "Back Button"))
			WindowName = "Menu";
		GUI.Label (new Rect(50 + 20, (50 * .5f) - 10, DifWindowRect.width, 30),"About", "Header Label");
		GUI.Label (new Rect(DifWindowRect.width - 45, 5, 40, 40), Logo, "Header Label");

		GUI.Label (new Rect (0, 60, DifWindowRect.width, DifWindowRect.height - 5), "", "Option Button");

		GUI.Label (new Rect(0, 65, DifWindowRect.width, DifWindowRect.height - 5), "This game was developed by",  "About Button");
		GUI.Label (new Rect(0, 65+35, DifWindowRect.width, 5), "Saidul Badhon with some help",  "About Button");
		GUI.Label (new Rect(0, 65+35+35, DifWindowRect.width, 5), "From Rurush, Hope you",  "About Button");
		GUI.Label (new Rect(0, 65+35+35+45, DifWindowRect.width, 5), "LOVE IT !!!! ;)",  "About Button2");

	}

	void GameOverWindow(int windowID){
		GUI.Label (new Rect(0, 0, DifWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, DifWindowRect.width, 7),"", "Under Header");
//		if (GUI.Button (new Rect (20, (50 * .5f) - 15, 30, 30), "", "Back Button"))
//			WindowName = "Menu";
		
		GUI.Label (new Rect((DifWindowRect.width / 2) - 50 , (50 * .5f) - 10, 100, 30),"Game Over", "Header Label");

		GUI.Label (new Rect (0, 60, DifWindowRect.width, 45), "", "Option Button");

		GUI.Label (new Rect(0, 65, DifWindowRect.width, DifWindowRect.height - 5), "Game is Over ! Please choose one !",  "About Button");

		if (GUI.Button (new Rect (0, 65 + 43, (DifWindowRect.width / 2) - 1, DifWindowRect.height - 3), "Restart", "GameOver Button")) {

			GetComponent<GameManager> ().SaveScore (true);

			GameObject.FindGameObjectWithTag("Game Menager").GetComponent<AdsManager>().ShowRewardedAd();

			Application.LoadLevel (Application.loadedLevelName.ToString ());
		}
		if (GUI.Button (new Rect ((DifWindowRect.width / 2) + 2, 65 + 43, (DifWindowRect.width / 2) - 1, DifWindowRect.height - 3), "Quit", "GameOver Button")) {
			GetComponent<GameManager> ().SaveScore (true);

			GameObject.FindGameObjectWithTag("Game Menager").GetComponent<AdsManager>().ShowDefaultAd();
			Application.LoadLevel (0);
		}

	}
}
