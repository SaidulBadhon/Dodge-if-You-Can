using UnityEngine;
using System.Collections;
//using UnityStandardAssets.ImageEffects;

public class GameMaster : MonoBehaviour {
	
//	public static GameMaster gm;
//	
//	void Awake () {
//		if (gm == null) {
//			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
//		}
//	}
//
//	void Update (){
//		if (Input.GetButtonDown ("PlayerKiller")) {
//			KillPlayer (GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ());
//		} else if (Input.GetKeyDown(KeyCode.L)) {
//			Application.LoadLevel(Application.loadedLevelName);
//		}
//	}
//	
//	public Transform playerPrefab;
//	public Transform spawnPoint;
//	public float spawnDelay = 2;
//	public Transform spawnPrefab;
//
//	public CameraShake cameraShake;
//
//	void Start() {
//		if (cameraShake == null) {
//			Debug.LogWarning("No camere shake referenced in GameMaster");
//			cameraShake = gameObject.GetComponent<CameraShake>();
//		}
//	}

//	public IEnumerator _RespawnPlayer () {
//		GetComponent<AudioSource>().Play ();
//		yield return new WaitForSeconds (spawnDelay);
//		
//		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
//		GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
//		Destroy (clone, 3f);
//	}
//	
//	public static void KillPlayer (Player player) {
//		Destroy (player.gameObject);
//		gm.StartCoroutine (gm._RespawnPlayer());
//	}
//	
//	public static void KillEnemy (/**Enemy enemy*/) {
//		gm._KillEnemy(enemy);
//	}
//	public void _KillEnemy (/*Enemy _enemy*/) {
//		GameObject _clone = Instantiate (_enemy.deathParticles, _enemy.transform.position, Quaternion.identity) as GameObject;
//		Destroy (_clone, 5);
//		cameraShake.Shake (_enemy.shakeAmt, _enemy.shakeLenth);
//		Destroy (_enemy.gameObject);
//	}
}

