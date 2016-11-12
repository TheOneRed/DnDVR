using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	float yRotation = 0.0f;

	void RoundTransform(){
		float xmod = this.transform.position.x % 11;
		float zmod = this.transform.position.z % 11;

		if (xmod > 5.5f) {
			xmod = 11 - xmod;
		} else {
			xmod = - xmod;
		}

		if (zmod > 5.5f) {
			zmod = 11 - zmod;
		} else {
			zmod = - zmod;
		}

		float x = this.transform.position.x + xmod;
		float z = this.transform.position.z + zmod;
		this.transform.position = new Vector3 (x, 0, z);
	}

	void ZeroRotation () {
		this.transform.rotation = new Quaternion (0.0f, yRotation, 0.0f, 0.0f);
	}

	void AddYRotation (float addVal) {
		yRotation += addVal;
		/*if (yRotation >= 360) {
			yRotation -= 360;
		}*/
		ZeroRotation ();
	}
}
