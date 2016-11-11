using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Transform player;

	// Use this for initialization
	void Start () {
		var rendum = Random.Range (1f, 3f);
		InvokeRepeating ("Shoot", 2, rendum);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.LookAt (player);
	}

	void Shoot() {
		
		var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 3;
		Destroy (bullet, 3.0f);
	}
}
