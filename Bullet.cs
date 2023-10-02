using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject fx;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
