using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrcBossProjectile : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        // Destroy object after 1.5 seconds
        Destroy(gameObject, 1.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("TakeDamage", 5);
            Destroy(gameObject);
        }
    }
}
