using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public bool canMove = true;
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public float range = 10.0f;
	public float damage = 35;

	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
//	private Transform frontPlayerCheck;		// Reference to the position of the gameobject used for checking if something is in front.
//	private bool dead = false;			// Whether or not the enemy is dead.

	public float attackRange = 10;
	public bool attackTarget;
	public Transform target;


	void Awake()
	{
		// Setting up the references.
		frontCheck = transform.Find("frontCheck").transform;
//		frontPlayerCheck = transform.Find("frontPlayerCheck").transform;
	}

	void Start() {
	}

	void FixedUpdate ()
	{
		if (GameObject.FindGameObjectWithTag ("Player").transform != null)
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		else
			return;

		// Set the enemy's velocity to moveSpeed in the x direction.
//		if (!attackTarget) {
		if(canMove)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);	
/*		}else if (attackTarget) {
//			Vector2 dis = target.transform.position - transform.position;
			Vector2 dis = target.transform.position - transform.position;

			float disfromPlayer = Vector3.Distance (target.position, transform.position);
			Debug.Log (disfromPlayer);

			if (disfromPlayer >= 2) {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2(dis.x,0.0f) * moveSpeed;
				Flip ();
			} else {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			}

//			GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);	

		}*/

//		if(frontPlayerCheck.gameObject.GetComponent<Collider2D>().tag == "Player"){
//			attackTarget = true;
//		}

		FindingPlayer ();
	}

	void FindingPlayer (){
		if (target == null)
			return;
		
		float dis = Vector3.Distance (target.position, transform.position);
		if(attackRange > dis){
			attackTarget = true;
		}
	}

	public void Flip() {
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		if(col.gameObject.tag != "Enemy" && col.gameObject.tag != "Player Bullet" && col.gameObject.tag != "Player")
		{
			// Instantiate the explosion and destroy the rocket.
			Flip ();
		}
		if(col.gameObject.tag == "Player"){
			col.GetComponent<PlayerHealth> ().curHealth -= damage;
		}
		if(col.gameObject.tag == "Enemy" && col.gameObject.name != transform.gameObject.name){
			Flip ();
		}
	}

}
