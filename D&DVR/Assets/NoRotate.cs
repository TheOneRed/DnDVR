using UnityEngine;
using System.Collections;

public class NoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//this.transform.rotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
	}

	void Round(){
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
		this.transform.position = new Vector3 (x, this.transform.position.y, z);
	}
}
