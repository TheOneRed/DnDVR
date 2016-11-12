using UnityEngine;
using System.Collections;

public class PlayerController : MovementScript {

    private Vector2 touchOrigin = -Vector2.one;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () 
	{
		int horizontal = 0;
		int vertical = 0;

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate (0, x, 0);
		transform.Translate(0, 0, z);

#if UNITY_IOS || UNITY_ANDROID || UNITY_IPHONE
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            
			if(myTouch.phase == TouchPhase.Began)
			{
				touchOrigin = myTouch.position;
        	}
			else if (myTouch.phase == TouchPhase.Ended)
			{
				Debug.Log (myTouch.position);
				Vector2 touchEnd = myTouch.position;
				float a = touchEnd.x - touchOrigin.x;
				float y = touchEnd.y - touchOrigin.y;
				touchOrigin.x = -1;

				if (Mathf.Abs(x) > Mathf.Abs(y))
					horizontal = x > 0 ?1 : -1;
				else
					vertical = y > 0 ?1 : -1;
			}
		}
		#endif
	}
}
	
