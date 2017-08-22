using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ControllerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

/*	void OnTriggerEnter2D (Collider2D col) 
	{
		//		Debug.Log ("Finding : " + col.name);
		// If it hits an enemy...
		if (col.gameObject.tag == "Spik") {
			Debug.Log ("Spik Found");
			// ... find the Enemy script and call the Hurt function.
			if (col.gameObject.GetComponent<Spik> ().demage != 0) {
				GetComponent<PlayerHealth> ().ReceivedDamage (col.gameObject.GetComponent<Spik> ().demage);
			} else if (col.gameObject.GetComponent<Spik> ().demage == 0) {
				float curdamage = Random.Range (70 - 5, 75 + 5);
				GetComponent<PlayerHealth> ().ReceivedDamage (curdamage);
			}

			if (col.gameObject.GetComponent<Spik> ().isKillZone == true) {
				GetComponent<PlayerHealth> ().ReceivedDamage (99999999);
			}
		}
	}
	void OnTriggerExit2D(Collider2D col) {
	}
*/
}
