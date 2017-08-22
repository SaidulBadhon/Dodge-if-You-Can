using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {

	public int levelIndex;
	
	public bool allTaskComplete = false;

	void Update(){
		allTaskComplete = GameObject.FindGameObjectWithTag ("Game Menager").GetComponent<ObjectiveManager> ().allObjComplete;

		if (!allTaskComplete) {
			GetComponent<MeshRenderer> ().material.color = Color.gray;
		} else if(allTaskComplete) {
			GetComponent<MeshRenderer> ().material.color = Color.green;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//		Debug.Log ("Finding");
		// If it hits an enemy...
		if (col.gameObject.tag == "Player") {
			//			Debug.Log ("Player Found");
			// ... find the Enemy script and call the Hurt function.
			if (allTaskComplete == true) {
				Debug.Log ("Level Complete");

				if (levelIndex >= 1) {
					Application.LoadLevel (levelIndex);
				} else if (levelIndex <= 0) {
					Application.LoadLevel (Application.loadedLevel + 1);
				}
			}
		}
	}
}
