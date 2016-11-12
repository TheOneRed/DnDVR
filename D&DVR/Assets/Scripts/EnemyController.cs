using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform player;
	float MoveSpeed = 1;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag ("Player").transform;
		
	}

	void Update(){
		
		transform.LookAt (player);
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	}


}
		

