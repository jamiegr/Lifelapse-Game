using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrOrb : MonoBehaviour {

    public Vector2 target = new Vector2(0.0f, 0.0f);
    public int health = 100;
    public int speed = 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Caller function for taking damage
    void TakeDamage(int damage)
    {
        StartCoroutine(Damaging(damage));
    }

    // Takes an amount of damage and causes simple effect
    IEnumerator Damaging(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            // Flash colour - to show hit
            transform.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
        else DeathSequence();
    }

    // Initiating damage
    void DeathSequence()
    {
        Destroy(gameObject);
    }
}
