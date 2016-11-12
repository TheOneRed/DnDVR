using UnityEngine;
using System.Collections;

public class AttackKeyController : MonoBehaviour {

    public GameObject sword;
    public Vector3 endSword;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            sword.transform.Rotate(endSword);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sword.transform.Rotate(50, 0, 0);
        }
    }
}
