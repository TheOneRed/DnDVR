using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag ("Player"))
		{
			var hit = collision.gameObject;
			var health = hit.GetComponent<Health>();
			if (health != null)
			{
				health.gainHealth(30);
			}
			Destroy(gameObject);
		}
	}
}
