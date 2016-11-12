using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	private int score = 100;
	private Health healthScript;
	// Use this for initialization
	void Start () {
		GameObject healthScriptObject = GameObject.FindWithTag ("Player");
		if (healthScriptObject != null) 
		{
			healthScript = healthScriptObject.GetComponent<Health> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 3, 0);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Player")) 
		{
			healthScript.gainScore(score);
			Destroy(gameObject);
		}
	}
}
