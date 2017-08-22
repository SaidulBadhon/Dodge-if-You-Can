using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	}

	void Fire() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject playerBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			playerBullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);

		}
	}

}
