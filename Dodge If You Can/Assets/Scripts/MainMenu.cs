using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects; //UnityStandardAssets.ImageEffects

public class MainMenu : MonoBehaviour {

	public GUISkin mySkin;

	public Texture2D menuButton;
	public Texture2D Logo;

	public Rect DifWindowRect = new Rect (0,0,0,0);
	public Rect AboutWindowRect = new Rect (0,0,0,0);

	public string WindowName = "Menu";
	private bool isMute;

	public bool deleteSaveData;

	void Start () {
		WindowName = "Menu";
		isMute = false;
		if (deleteSaveData)
			PlayerPrefs.DeleteAll ();
	}
	
	void Update () {
		if (isMute == true) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}

//		DifWindowRect = new Rect ((Screen.width * .5f) - (275), (Screen.height * .5f) - (324 / 2), 550, 324);
		DifWindowRect = new Rect (0, (Screen.height * .5f) - ((324+50+3) / 2), 450, 324+50+3);
		AboutWindowRect = new Rect (0, (Screen.height * .5f) - ((410+50+3) / 2), 450, 410+50+3);

	}

	void OnPouse(){
	}

	void OnGUI(){
		GUI.skin = mySkin;
		GUI.Label (new Rect (Screen.width - (DifWindowRect.width), 0, DifWindowRect.width, 50), "Score : " + PlayerPrefs.GetInt("Score").ToString(), "Menu Text");
			
		if (WindowName == "Menu") {
			DifWindowRect = GUI.Window (0, DifWindowRect, MainMenuWindow, "", "My Window");
		} else if (WindowName == "Option") {
			DifWindowRect = GUI.Window (0, DifWindowRect, OptionWindow, "", "My Window");
		} else if (WindowName == "About") {
			AboutWindowRect = GUI.Window (0, AboutWindowRect, AboutWindow, "", "My Window");
		} else if (WindowName == "GameOver") {
			DifWindowRect = GUI.Window (0, DifWindowRect, GameOverWindow, "", "My Window");
		} 
	}

	void MainMenuWindow(int windowID) {
		GUI.Label (new Rect(0, 0, DifWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, DifWindowRect.width, 7),"", "Under Header");
		GUI.Label (new Rect(20, (50 * .5f) - 10, DifWindowRect.width, 30),"DodgE if you can !!", "Header Label");
		GUI.Label (new Rect(DifWindowRect.width - 45, 5, 40, 40), Logo, "Header Label");

		if (GUI.Button (new Rect(0, 60, DifWindowRect.width, 50), "Play", "Menu Text")) {
			Application.LoadLevel (1);
		}

		if (GUI.Button (new Rect(0, 60 + 50 + 3, DifWindowRect.width, 50), "Load & Save", "Menu Text")) {
			Application.LoadLevel (1);
		}
		if (GUI.Button (new Rect(0, 60 + 100 + 6, DifWindowRect.width, 50), "Edit Player", "Menu Text")) {
//			WindowName = "Option";
		}
		if (GUI.Button (new Rect(0, 60 + 150 + 9, DifWindowRect.width, 50), "Option", "Menu Text")) {
			WindowName = "Option";
		}
		if (GUI.Button (new Rect(0, 60 + 200 + 12, DifWindowRect.width, 50), "About", "Menu Text")) {
			WindowName = "About";
		}
		if (GUI.Button (new Rect(0, 60 + 250 + 15, DifWindowRect.width, 50), "Quit", "Menu Text")) {
			Application.Quit ();
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
		GUI.Label (new Rect(0, 0, AboutWindowRect.width, 50),"", "Header");
		GUI.Label (new Rect(0, 50, AboutWindowRect.width, 7),"", "Under Header");
		if (GUI.Button (new Rect (20, (50 * .5f) - 15, 30, 30), "", "Back Button"))
			WindowName = "Menu";
		GUI.Label (new Rect(50 + 20, (50 * .5f) - 10, AboutWindowRect.width, 30),"About", "Header Label");
		GUI.Label (new Rect(AboutWindowRect.width - 45, 5, 40, 40), Logo, "Header Label");

		GUI.Label (new Rect (0, 60, AboutWindowRect.width, AboutWindowRect.height - 5), "", "Option Button");
//		Thanks for playing our game, Hope you liked it!

//			This game would not been possible without the help of Saidul Badhon, Jonaet Islam, Leon Ruiz and Ayuobo.

//			You can contact them at : TheWagar@gmail.com, Jonaet32@gmail.com, SaidulBadhon@gmail.com.

		GUI.Label (new Rect(0, 65, AboutWindowRect.width, AboutWindowRect.height - 5), "Thanks for playing our game, Hope you liked it!\n\nThis game would not been possible without the help of Saidul Badhon, Jonaet Islam, Leon Ruiz and Ayuobo.\n\nYou can contact them at : TheWagar@gmail.com, Jonaet32@gmail.com, SaidulBadhon@gmail.com.",  "About Button");


//		GUI.Label (new Rect(0, 65, DifWindowRect.width, DifWindowRect.height - 5), "This game was developed by",  "About Button");
//		GUI.Label (new Rect(0, 65+35, DifWindowRect.width, 5), "Saidul Badhon with some help",  "About Button");
//		GUI.Label (new Rect(0, 65+35+35, DifWindowRect.width, 5), "From Rurush, Hope you",  "About Button");
//		GUI.Label (new Rect(0, 65+35+35+45, DifWindowRect.width, 5), "LOVE IT !!!! ;)",  "About Button2");

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
			Application.LoadLevel (Application.loadedLevelName.ToString ());
		}
		if (GUI.Button (new Rect ((DifWindowRect.width / 2) + 2, 65 + 43, (DifWindowRect.width / 2) - 1, DifWindowRect.height - 3), "Quit", "GameOver Button")) {
			Application.LoadLevel (0);
		}

	}
}
