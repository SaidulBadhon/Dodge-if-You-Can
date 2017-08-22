using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public GameObject explosion;		// Prefab of explosion effect.

	public float curHealth;
	public float maxHealth = 100;

	public float addScore = 100;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth <= 0) {
			curHealth = 0;
		}
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth == 0) {
			OnExplode ();
		}
	}

	void OnExplode()
	{

		GameObject.FindGameObjectWithTag("Game Menager").GetComponent<GameCurrencyManager>().SendMessage("AddScore", addScore);


		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
		Destroy(gameObject);

	}
	public void ReceivedDamage(float amount){
		curHealth -= amount;
	}


}
