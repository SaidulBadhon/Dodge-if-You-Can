using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	public GameObject exp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


/*	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Player"){
			GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameCurrencyManager> ().gold += 1;

			GameObject _exp = Instantiate (exp, transform.position, transform.rotation) as GameObject;

			Destroy (this);
		}


	}
	*/
	void OnCollisionEnter2D (Collision2D col)
	{
		//		Debug.Log ("Finding");
		// If it hits an enemy...
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player Found");
			GameObject.FindGameObjectWithTag ("Game Menager").GetComponent<GameCurrencyManager> ().SendMessage("AddGold", 1);

            GameObject _exp = Instantiate (exp, transform.position, transform.rotation) as GameObject;

			Destroy (transform.gameObject);

					// ... find the Enemy script and call the Hurt function.
		}
	}
}
