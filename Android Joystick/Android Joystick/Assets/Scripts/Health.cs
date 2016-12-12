using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Text healthLabel;
	public Text scoreLabel;
	private int currentHealth = 100;
	public int currentScore = 0;

	// Use this for initialization
	void Start () {
		this.displayHealth ();
		this.displayScore ();
        //healthLabel = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        //scoreLabel = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        healthLabel = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        scoreLabel = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		displayHealth ();

		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	public void gainHealth(int amount)
	{
		currentHealth += amount;
		displayHealth ();
	}

	public void gainScore(int amount)
	{
		currentScore += amount;
		displayScore ();
	}

	public void displayHealth() 
	{
		healthLabel.text = ("Health: " + currentHealth);
	}

	public void displayScore() 
	{
		scoreLabel.text = ("Score: " + currentScore);
	}
}
