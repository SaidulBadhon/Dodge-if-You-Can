using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public Rigidbody2D projectile;
	public float bulletSpeed = 10;
	public Transform target;

	public Transform turretHead;
	public GameObject shootPoint;

	public float attackRange = 10;
	public bool attackTarget;

	float fireRate = .5f;
	float nextFire = 0.0f;

	void Start(){
//		RepeatShooting();
	}

	void Update(){
		if (GameObject.FindGameObjectWithTag ("Player").transform != null)
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		else
			return;
		
		if (target == null)
			return;
		
		if(attackTarget){
			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - turretHead.transform.position, turretHead.transform.TransformDirection(Vector3.up));
			turretHead.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
			RepeatShooting ();
//			LaunchProjectile();
		}

		float dis = Vector3.Distance (target.position, transform.position);
		if(attackRange > dis){
			attackTarget = true;
		}

	}
	// Shoot and repeat

	void RepeatShooting () {
		InvokeRepeating ("LaunchProjectile", .1f, 0.3f);
	}


	public void LaunchProjectile(){
		if (attackTarget && target != null && shootPoint != null) {
			
//		if (Time.time > nextFire) {
//
//			Vector2 direction = target.transform.position - transform.position;
//			direction.Normalize();
//
//			GameObject bulletClone;
//			bulletClone = Instantiate (projectile, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
//			bulletClone.GetComponent<Rigidbody2D>().velocity = direction* bulletSpeed;
//			//				bullet.AddForce(transform.forward * bulletSpeed);
//
//			//				bullet.transform.position = shootPoint.transform.forward*bulletSpeed * Time.deltaTime;
//		}




			//Vector3 projectileStart = new Vector3(

			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
	//			Vector2 direction = target.transform.position - transform.position;
	//			direction.Normalize();

				Instantiate (projectile, shootPoint.transform.position, shootPoint.transform.rotation);
	//			transform.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed, 0, 0);;

	//			GameObject bullet = Instantiate (projectile, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
	//			bullet.GetComponent<Rigidbody2D>().velocity = direction* bulletSpeed;

	//			bullet.GetComponent<Rigidbody2D>().AddForce(shootPoint.transform.forward * bulletSpeed);
	//			bullet.transform.position = shootPoint.transform.forward*bulletSpeed * Time.deltaTime;
			}
		}
	}

}
