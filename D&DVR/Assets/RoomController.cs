using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

	public Material WallMat;
	public Material SlectMat;
	public Material invalidMat;
	public bool switchedMat = true;
	public bool invalidPlacment = true;

	void Start(){
		if (!invalidPlacment) {
			MakeValid ();
		}
	}

	public void RoundTransform(){
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

	public void ZeroRotation () {
		this.transform.rotation = new Quaternion (0.0f, 0.0f , 0.0f, 0.0f);
	}

	public void Slected () {
		ChangeWallMat (SlectMat);
	}

	public void UnSlect () {
		if (invalidPlacment) {
			ChangeWallMat (invalidMat);
		} else {
			ChangeWallMat (WallMat);
		}
	}

	public void MakeValid () {
		invalidPlacment = false;

		this.gameObject.layer = 10;
		Transform[] gs = this.GetComponentsInChildren<Transform> ();
		foreach (Transform g in gs) {
			g.gameObject.layer = 10;
		}

		UnSlect ();
	}

	public void Placed () {
		DoorController[] doors = GetComponentsInChildren<DoorController> ();
		foreach (DoorController d in doors) {
			d.Placed ();
		}

		if (!invalidPlacment) {
			MakeValid ();
		} else {
			ChangeWallMat (invalidMat);
		}
	}

	void ChangeWallMat (Material newMat) {
		MeshRenderer[] wallMR = GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer mr in wallMR) {
			if (mr.gameObject.tag.Equals ("Wall")) {
				mr.material = newMat;
			}
		}
	}
}
