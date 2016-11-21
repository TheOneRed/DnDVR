using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraScript : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;
	Quaternion originalRotation;

	public float pickUpRange;
	GameObject picked;

	// Use this for initialization
	void Start () {
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		

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


			if (axes == RotationAxes.MouseXAndY)
			{
				// Read the mouse input axis
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationX = ClampAngle (rotationX, minimumX, maximumX);
				rotationY = ClampAngle (rotationY, minimumY, maximumY);
				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
				Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
				transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			}
			else if (axes == RotationAxes.MouseX)
			{
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				rotationX = ClampAngle (rotationX, minimumX, maximumX);
				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
				transform.localRotation = originalRotation * xQuaternion;
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = ClampAngle (rotationY, minimumY, maximumY);
				Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
				transform.localRotation = originalRotation * yQuaternion;
			}
	
	}
}

		public static float ClampAngle (float angle, float min, float max)
		{
			if (angle < -360F)
				angle += 360F;
			if (angle > 360F)
				angle -= 360F;
			return Mathf.Clamp (angle, min, max);
		}
}

