using UnityEngine;
using System.Collections;

public class SaveGame  : MonoBehaviour {
	public string playerName = "Hero";
	public int score;
	public float health;
	public Vector3 playerPosition;


	public void SavePlayerName(string _name){
		PlayerPrefs.SetString("Player Name", _name);
		SavePlayerPrefs ();
	}

	public void SaveScore(int _score){
		int curScore = PlayerPrefs.GetInt ("Score");

		Debug.Log ("Cur Score : " + curScore);
		Debug.Log ("New Score : " + _score);

		PlayerPrefs.SetInt ("Score", curScore + _score);
		SavePlayerPrefs ();
	}

	public void SaveHealth(float _health){
		Debug.Log ("SaveHealth : " + _health);
		PlayerPrefs.SetFloat ("Player Health", _health);
		SavePlayerPrefs ();
	}

	public void SavePlayerPosition(Vector3 _playerPosition){
		PlayerPrefs.SetFloat ("Player Pos X", _playerPosition.x);
		PlayerPrefs.SetFloat ("Player Pos Y", _playerPosition.y);
		PlayerPrefs.SetFloat ("Player Pos Z", _playerPosition.z);
		SavePlayerPrefs ();
	}

	private void SavePlayerPrefs(){
		PlayerPrefs.Save ();
	}
}
