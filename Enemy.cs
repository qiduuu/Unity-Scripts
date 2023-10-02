using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Camera cam;

    public GameObject fx;

    public float speed;

    public GameObject target;

    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        playerPos = target.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
