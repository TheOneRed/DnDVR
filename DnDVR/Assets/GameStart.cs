using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject Player;
	public Transform player;

	// Use this for initialization
	void Start () {

		Instantiate (Player, player.position, player.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
