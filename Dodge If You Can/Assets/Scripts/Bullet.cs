using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject explosion;		// Prefab of explosion effect.

	public float bulletSpeed = 10;
	public GameObject target;
	public float damage = 10;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = target.transform.position - transform.position;
		direction.Normalize();

//		transform.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);
//		transform.GetComponent<Rigidbody2D>().velocity = transform.forward* bulletSpeed;
		transform.GetComponent<Rigidbody2D>().velocity = direction* bulletSpeed;
//		transform.Translate( transform.forward * bulletSpeed * Time.deltaTime );

	}

	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}

/*	void OnCollisionEnter2D(Collision2D other){
//		Debug.Log ("NAme : " + other.gameObject.name);
		if(other.gameObject.tag == "Player"){
			Debug.Log ("Hit Player");
			float curdamage = Random.Range (damage - 5, damage + 5);
			other.gameObject.GetComponent<PlayerHealth> ().ReceivedDamage (curdamage);
		}
	
//		if (other.gameObject != null && other.gameObject.tag != "Enemy") {
//			Destroy (gameObject);
//		}
	}
	*/
	void OnTriggerEnter2D (Collider2D col) 
	{
		if(col.gameObject.tag == "Player"){
//			Debug.Log ("Hit Player");
			float curdamage = Random.Range (damage - 5, damage + 5);
			col.gameObject.GetComponent<PlayerHealth> ().ReceivedDamage (curdamage);
		}

		if(col.gameObject.tag != "Enemy")
		{
			// Instantiate the explosion and destroy the rocket.
			OnExplode();
			Destroy (gameObject);
		}
	}


}
