using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public float MoveSpeed = 1;
    public AudioSource DeathSound;

    // Use this for initialization
    void Start () {
        DeathSound = GetComponent<AudioSource>();
        //player = GameObject.FindWithTag ("Player").transform;

    }

	void Update(){
        player = GameObject.FindWithTag("Player").transform;
        transform.LookAt (player);
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {

            if (collision.gameObject.tag == "Player")
            {
                var hit = collision.gameObject;
                var health = hit.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(10);
                }


                //Destroy(gameObject);
            }
        }
    }


       void OnTriggerEnter(Collider collision)
    {
            if (collision.CompareTag ("Sword"))
            {
            // hit = collision.gameObject;
            //var health = hit.GetComponent<Health>();
            //if (health != null)
            //{
            //    health.gainScore(10);
            //}

            //Destroy(gameObject);
            DeathSound.Play();
            Invoke("DestroyEnemy", 0.5f);

            // health.gainScore(10);
            //health.displayScore();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        //decrement a life
        //this.gamecontroller.Life -= 1;
    }
}
		

