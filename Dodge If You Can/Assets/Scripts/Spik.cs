using UnityEngine;
using System.Collections;

public class Spik : MonoBehaviour {
	public bool isKillZone = false;
	public int demage = 0;

		void Update (){
//		Debug.Log ("Finding");
	}

	void OnCollisionEnter2D (Collision2D col)
	{
//		Debug.Log ("Finding");
		// If it hits an enemy...
		if (col.gameObject.tag == "Player") {
//			Debug.Log ("Player Found");
			// ... find the Enemy script and call the Hurt function.
			float curdamage = Random.Range (70 - 5, 75 + 5);
			col.gameObject.GetComponent<PlayerHealth> ().ReceivedDamage (curdamage);
		}

		if (isKillZone) {
			if (col.gameObject.tag == "Player") {
//				Debug.Log ("Player Found");
				// ... find the Enemy script and call the Hurt function.
				float curdamage = Random.Range (100, 110);
				col.gameObject.GetComponent<PlayerHealth> ().ReceivedDamage (curdamage);
			}
		}
	}

}
