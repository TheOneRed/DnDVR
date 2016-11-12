using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

	public Transform player;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag ("Player").transform;
		var rendum = Random.Range (1f, 3f);
		InvokeRepeating ("Shoot", 2, rendum);
	
	}

	void Update(){
		
		transform.LookAt (player);
	}

	void Shoot() {
		
		var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 3;
		Destroy (bullet, 3.0f);
	}
}
