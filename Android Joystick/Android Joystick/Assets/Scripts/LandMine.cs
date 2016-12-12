using UnityEngine;
using System.Collections;

public class LandMine : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(20);
		}
		Destroy(gameObject);
	}

}
