using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public AudioSource starSound;

    // Use this for initialization
    void Start()
    {
        starSound = GetComponent<AudioSource>();
        //player = GameObject.FindWithTag ("Player").transform;

    }


    // Update is called once per frame
    void Update () {
		this.transform.Rotate (0, 3, 0);
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag ("Player"))
		{
			var hit = collision.gameObject;
			var health = hit.GetComponent<Health>();
			if (health != null)
			{
                health.gainScore(20);
			}
            starSound.Play();
            Invoke("DestroyStar", 0.5f);
		}
	}

    void DestroyStar()
    {
        Destroy(gameObject);
        //decrement a life
        //this.gamecontroller.Life -= 1;
    }
}
