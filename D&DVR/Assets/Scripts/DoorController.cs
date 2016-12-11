using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool placed = false;
	public RoomController rc;

	void Start(){
		rc = GetComponentInParent<RoomController> ();
		print (rc);
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag.Equals("Door")) {
			DoorController otherDoor = collision.gameObject.GetComponent<DoorController> ();
			if (placed && otherDoor.placed && !otherDoor.rc.invalidPlacment) {
				rc.MakeValid();
				Destroy (this.gameObject);
				Destroy (otherDoor.gameObject);
			}
		}
	}

	public void Placed () {
		placed = true;
	}
}
