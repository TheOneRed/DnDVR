using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	public float pickUpRange;
	GameObject picked;

	/*void Update ()
	{
		
	}*/

	void Update() {
		RaycastHit hit;
		int layerMask = 1 << 8;
		int layerMask2 = 1 << 9;

		if (Input.GetMouseButtonUp (0)) {
			Cursor.visible = false;
		} 

		if (Input.GetMouseButtonUp (0)) {
			if(Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, layerMask2) && hit.collider.gameObject.tag.Equals("Room"))
			{
				if (picked == null) {
					picked = hit.collider.gameObject;
				} else if (picked != null) {
					picked.SendMessage ("RoundTransform");
					picked = null;
				}
			}
		}

		/*if (Input.GetMouseButtonUp (1) && picked != null) {
			picked.SendMessage ("AddYRotation", 0.5f);
		}*/

		if (picked != null && Physics.Raycast (transform.position, transform.forward, out hit, float.MaxValue, layerMask)) {
			picked.transform.position = hit.point;
			picked.SendMessage ("ZeroRotation");
		}
	}
}