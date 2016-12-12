using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour 
{

	public float moveForce = 5, boostMultipler = 2;
	Rigidbody myPlayer;
    //public GameObject sword;
    public Transform swordTransform;
    public Transform swordRotation;
    public Transform swordRotationInitial;
    //swordTransform = transform.FindChild("Sword");

    // Use this for initialization
    void Start () 
	{
		myPlayer = this.GetComponent<Rigidbody>();
	}

	void Update ()
	{
        //sword = GameObject.FindGameObjectWithTag("Sword");
        swordTransform = GameObject.FindWithTag("Sword").transform;
        swordRotation = GameObject.FindWithTag("SwordRotation").transform;
        swordRotationInitial = GameObject.FindWithTag("SwordRotationInitial").transform;
    }
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Vector3 moveVec = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal"),0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
		bool isBoosting = CrossPlatformInputManager.GetButton ("Boost");

		Vector3 lookVec = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"), 4000);

		//This is needed so that the rotation does not snap back to the original if they are not both zero dont snapback
		if (lookVec.x != 0 && lookVec.y != 0) {
			transform.rotation = Quaternion.LookRotation (lookVec, Vector3.back);
		}

		Debug.Log (isBoosting ? boostMultipler : 1);
		//a single line if else statment , is the player boosting? if its true its use multiplier if false use 1
		myPlayer.AddForce (moveVec * (isBoosting ? boostMultipler : 1));
        //Vector3 swordMove = new Vector3(4, 4, 4);
        //sword.transform.Translate(swordMove);
        //if(isBoosting == false)
        //{
        //    swordTransform.transform.localPosition;
        //}

        if (isBoosting == true)
        {                                                                                       //new Vector3(-0.92f, -0.60f, 0.30f), 1.0f)
                                                                                                //new Vector3(-13.39f, 0.45f, -0.30f), 1.0f)
                                                                                                //new Vector3(-0.84f, 0.27f, -0.46f), 1.0f)
            swordTransform.transform.localPosition = Vector3.Lerp(swordTransform.localPosition, new Vector3(-0.64f, 0.07f, -0.26f), 0.3f);
            swordTransform.rotation = Quaternion.Slerp(swordTransform.rotation, swordRotation.rotation, 0.3f);
            //swordTransform.transform.localPosition = Vector4.Lerp(swordTransform.localPosition, new Vector4(-0.64f, 0.07f, -0.26f, -99.0f), 0.7f);
        }
        if(isBoosting == false)
        {
            swordTransform.transform.localPosition = Vector3.Lerp(swordTransform.localPosition, new Vector3(-0.86f, -0.60f, 0.40f), 0.31f);
            swordTransform.rotation = Quaternion.Slerp(swordRotation.rotation, swordRotationInitial.rotation, 0.3f);
        }
        

    }

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
	}

}
