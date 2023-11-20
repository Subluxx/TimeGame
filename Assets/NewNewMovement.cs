using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNewMovement : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float currentSpeed = 1;
    [SerializeField] private float acceleration = 4f;
    [SerializeField] private float maxAcceleration = 8;
    [SerializeField] private float currentAcceleration = 1.5f;
    [SerializeField] private float jumpForce = 0.3f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isWalled = false;

    //private bool isMoving = false;
    //private float decceleration = 8;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && isWalled == true)
        {
            rb.AddForce(transform.up * jumpForce * 2, ForceMode2D.Impulse);
            isGrounded = false;
            isWalled = false;
        }

        if (isGrounded == true && !Input.anyKey)
        {
            rb.drag = 2;
        }
        else
        {

            rb.drag = 0;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            isWalled = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            isWalled = true;

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            currentAcceleration += acceleration;
            rb.AddForce(transform.right * (currentSpeed += currentAcceleration) * (Time.deltaTime));
            //isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentAcceleration += acceleration;
            rb.AddForce(-transform.right * (currentSpeed += currentAcceleration) * (Time.deltaTime));
            //isMoving = true;
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        if (currentAcceleration >= maxAcceleration)
        {
            currentAcceleration = maxAcceleration;
        }

        if (currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        /*
        if (isMoving == false && currentSpeed > 0) 
        {
            rb.AddForce(transform.right * (currentSpeed -= decceleration));
        }
          */

    }
}