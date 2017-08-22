using UnityEngine;
using System.Collections;

public class GameCurrencyManager : MonoBehaviour {
//	Currency Type
	public int score = 0;
	public int gold = 0;
	public int gem = 0;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
//		GetComponent<SaveGame> ().SaveScore (score);
	}

    void AddScore(int RecScore)
    {
        score += RecScore;
        print("Score : " + RecScore);
    }
    void AddGold(int RecGold)
    {
        score += RecGold;
        print("Gold : " + RecGold);
    }
    void AddGem(int RecGem)
    {
        score += RecGem;
        print("GEm : " + RecGem);
    }

    public void ScoreGUI(){
		GUI.Label (new Rect (25, 60, 175, 50), "Score : " + score);
		GUI.Label (new Rect (25, 60 + 50, 175, 50), "Gold : " + gold);
		GUI.Label (new Rect (25, 60 + 50 + 50, 175, 50), "Gem : " + gem);
	}
}
