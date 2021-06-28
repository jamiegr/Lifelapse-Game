using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrcBoss : MonoBehaviour {

    private readonly int proj_speed = 1100;
    private readonly int move_speed = 4;
    private int move_horizontal = 0;
    private int shooting_phase = 0;
    private bool shooting = false;

    public GameObject fire_point;
    public GameObject projectile;
    public int health = 200;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        Vector2 target = new Vector2(0.0f, 0.0f);
        transform.position = Vector2.MoveTowards(transform.position, target, 10 * Time.deltaTime);

        // Conditional actions
        float shooting_interval = 0.8f;
        if (shooting_phase == 1) shooting_interval = 0.6f;
        else if (shooting_phase == 2) shooting_interval = 0.4f;
        // Shoot based on interval
        if (!shooting) StartCoroutine(Shoot(shooting_interval));
        // Always look at player and move
        LookAtPlayer();
        Movement();
    }

    void Movement() {
        // Move based on horizontal index
        if (move_horizontal == 0) transform.position += Vector3.right * (Time.deltaTime * move_speed);      
        else if (move_horizontal == 1) transform.position += Vector3.right * -(Time.deltaTime * move_speed);
        // Invert movement when bounds are reached
        if (transform.position.x >= 10) move_horizontal = 1;
        else if (transform.position.x <= -10) move_horizontal = 0;
    }

    void LookAtPlayer() {
        // Find the player
        GameObject target = GameObject.FindWithTag("Player");
        // Get the angle to rotate at player
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(90 + angle, Vector3.forward);
    }

    IEnumerator Shoot(float time) {
        shooting = true;
        // Create projectile and apply velocity
        GameObject current_projectile = Instantiate(projectile, fire_point.transform.position, fire_point.transform.rotation);
        current_projectile.GetComponent<Rigidbody2D>().velocity = -current_projectile.transform.up * (Time.deltaTime * proj_speed);
        yield return new WaitForSeconds(time);
        shooting = false;
    }

    void TakeDamage(int damage) {
        health -= damage;
        
        if (health <= 0) DeathSequence();
        else if (health <= 75) shooting_phase = 2;
        else if (health <= 125) shooting_phase = 1;
    }

    void DeathSequence() {
        Destroy(gameObject);
    }
}
