using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerC : NetworkBehaviour {

	public bool Local;

	// Use this for initialization
	void Start () {
		Local = isLocalPlayer;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		/*if (Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}*/
	}
}
