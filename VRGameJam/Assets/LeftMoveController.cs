using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeftMoveController : MonoBehaviour
{

    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

	void OnButtonClick()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		transform.Rotate (0, x, 0);
	}
}
