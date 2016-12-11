using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

	public GameObject ServerPlayer;
	public GameObject ClientPlayer;
	public GameObject Camera;

	public static bool ServerIn = false;

	public enum State{IS_NULL, IS_VR, IS_TABLIT}
	public State PlayerState;

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
	RoomController picked;

	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
		{
			return;
		}

		if (PlayerState == State.IS_VR)
		{
			VRStart ();
		}
		else if (PlayerState == State.IS_TABLIT)
		{
			TBStart ();
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		if (PlayerState == State.IS_VR)
		{
			VRUpdate ();
			VRClick ();
		}
		else if (PlayerState == State.IS_TABLIT)
		{
			TBUpdate();
		}
	}

	public override void OnStartLocalPlayer()
	{
		//GetComponent<MeshRenderer>().material.color = Color.blue;

		Camera = (GameObject)Instantiate (Camera);
		Camera.transform.parent = this.transform;
	}

	public override void OnStartClient ()
	{
		GameObject player;
		if (ServerIn) {
			player = (GameObject)Instantiate (ClientPlayer);
			PlayerState = State.IS_TABLIT;
		} else {
			player = (GameObject)Instantiate (ServerPlayer);
			PlayerState = State.IS_VR;
			ServerIn = true;
		}
		player.transform.parent = this.transform;
	}

	public void VRStart()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	public void VRUpdate()
	{
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

	public void VRClick()
	{
		RaycastHit hit;
		int layerMask = 1 << 8;
		int layerMask2 = 1 << 9;

		/*if (Input.GetMouseButtonUp (0)) {
			Cursor.visible = false;
		}*/

		if (Input.GetMouseButtonUp (0)) {
			if(Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, layerMask2) && hit.collider.gameObject.tag.Equals("Room"))
			{
				if (picked == null) {
					picked = hit.collider.gameObject.GetComponent<RoomController> ();
					picked.ZeroRotation ();
					picked.Slected ();
				} else if (picked != null) {
					picked.Placed ();
					picked.UnSlect ();
					picked = null;
				}
			}
		}

		if (picked != null && Physics.Raycast (transform.position, transform.forward, out hit, float.MaxValue, layerMask)) {
			picked.transform.position = hit.point;
			picked.RoundTransform ();
		}
	}

	public void TBStart ()
	{
		foreach (Transform t in GetComponentsInChildren<Transform>()) {
			if (t.tag == "CamTransform") {
				Camera.transform.position = t.position;
				Camera.transform.rotation = t.rotation;
			}
		}
	}

	public void TBUpdate()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
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
