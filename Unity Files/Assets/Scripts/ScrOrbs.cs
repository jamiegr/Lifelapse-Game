using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrOrbs : MonoBehaviour {

    public float circle_forward = 1f;
    public float circle_speed = 1f;
    public float circle_size = 1f;

    public int health = 100;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = Mathf.Cos(Time.time * circle_speed) * circle_size * Time.deltaTime;
        transform.position += new Vector3(circle_forward * Time.deltaTime, yPos, 0);
    }

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
            transform.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
        else DeathSequence();
    }
    void DeathSequence()
    {
        Destroy(gameObject);
    }
}
