using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerHealth : MonoBehaviour {

	public float minHealth = 0;
	public float curHealth;
	public float maxHealth = 100;


	void Awake (){}

	void Start () {curHealth = maxHealth;}
	
	void Update () {
		if (curHealth <= 0) {
			curHealth = 0;
		}
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;
		}
	}

	public void HealthGUI(){GUI.Label (new Rect (25, 10, 175, 50), "Health : " + (int)curHealth);}

	public void ReceivedDamage(float amount){curHealth -= amount;}

/*	void OnTriggerEnter2D (Collider2D col) 
	{
//		Debug.Log ("Finding : " + col.name);
		// If it hits an enemy...
		if (col.gameObject.tag == "Spik") {
			Debug.Log ("Spik Found");
			// ... find the Enemy script and call the Hurt function.
			float curdamage = Random.Range (70 - 5, 75 + 5);
			ReceivedDamage (curdamage);
		}
	}
	void OnTriggerExit2D(Collider2D col) {
	}
*/
}