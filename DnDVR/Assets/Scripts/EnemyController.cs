using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform player;
	float MoveSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			transform.LookAt (player);
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;

	}

}
		

