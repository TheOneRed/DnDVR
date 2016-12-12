using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

	public Transform player;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
    public AudioSource arrowSound;

    // Use this for initialization
    void Start () {
		

		var rendum = Random.Range (1f, 3f);
		InvokeRepeating ("Shoot", 1, rendum);
        arrowSound = GetComponent<AudioSource>();
	}

	void Update(){
		player = GameObject.FindWithTag ("Player").transform;
		transform.LookAt (player);
	}

	void Shoot() {
		
		var bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        arrowSound.Play();
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 3;
		Destroy (bullet, 3.0f);
	}
}
