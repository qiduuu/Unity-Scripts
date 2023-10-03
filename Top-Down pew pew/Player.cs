using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Camera sceneCamera;

    public float speed;

    public GameObject fx;

    public Weapon weapon;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    private Vector2 mousePosition;

    void Start()
    {

    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            // make the particles go pewewewewewew kabooom kapow kaplowieeeee
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);

            SceneManager.LoadScene("Main");
        }

        if(collision.tag == "Wall")
        {
            // sane thingsd
            Instantiate(fx, transform.position, Quaternion.identity);

            Destroy(gameObject);

            SceneManager.LoadScene("Main");
        }
    }

    void Move()
    {

        // what does all these even mean i mean i get it but no i dont also huh why is it mathf.rad2deg -90f??? is that an issue with its direction in the scene??? WHY WOULD IT BE -90f!?!??!?!?
        
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        Vector2 aimDirection = mousePosition - rb.position;

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = aimAngle;
    }
}
