using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	public bool allObjComplete = false;


	public bool haveToKillAllEnemys;
	public bool haveToGetAllGolds;
	public bool haveToGetScore;

	public int goldNeeded = 6;
	public int scoreNeeded = 1500;

	private bool allEnemys = false;
	private bool allGold = false;
	private bool allScore = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateObjectives ();

		if (allEnemys && allGold && allScore){
			allObjComplete = true;
		}
	}

	void UpdateObjectives () {
		if (haveToKillAllEnemys) {
			GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
			if (enemy == null) {
				allEnemys = true;
			} else {
				allEnemys = false;
			}
		} else if (!haveToKillAllEnemys) {
			allEnemys = true;
		}

		if (haveToGetAllGolds) {
			if (goldNeeded <= GetComponent<GameCurrencyManager> ().gold) {
				allGold = true;
			} else
				allGold = false;
		} else if (!haveToGetAllGolds) {
			allGold = true;
		}

		if (haveToGetScore) {
			if (scoreNeeded <= GetComponent<GameCurrencyManager> ().score) {
				allScore = true;
			} else
				allScore = false;
		} else if (!haveToGetScore) {
			allScore = true;
		}
	}
}
