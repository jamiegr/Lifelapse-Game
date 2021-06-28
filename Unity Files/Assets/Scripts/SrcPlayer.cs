using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrcPlayer : MonoBehaviour
{
    public int health = 100;
    public int speed = 10;
    public GameObject projectile;
    private readonly int proj_speed = 1000;
    private bool proj_flag = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * -(speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && proj_flag)
        {
            Shoot();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health >= 0)
        {
            DeathSequence();
        }
    }

    void DeathSequence()
    {

    }

    void Shoot()
    {
        proj_flag = false;
        // Spawn Projectile and shoot
        GameObject current_projectile = Instantiate(projectile, transform.position + (transform.forward * 2 * Time.deltaTime), transform.rotation);
        // Apply velocity
        current_projectile.GetComponent<Rigidbody2D>().velocity = current_projectile.transform.up * (Time.deltaTime * proj_speed);
        StartCoroutine("ShootCoolDown");
    }
    IEnumerator ShootCoolDown() 
    {
        yield return new WaitForSeconds(.2f);
        proj_flag = true;
    }
}
