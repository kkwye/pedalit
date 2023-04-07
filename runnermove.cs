using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnermove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello from start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {




        /*
        if (Input.GetKeyDown("space") && IsGrounded()) // jump up
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
        
        if (Input.GetKeyDown("up")) // forwards
        {
            rb.velocity = new Vector3(0, 0, moveSpeed);
        }
        
        rb.velocity = new Vector3(0, 0, moveSpeed);

        if (Input.GetKeyDown("right"))
        {
            rb.velocity = new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKeyDown("left"))
        {
            rb.velocity = new Vector3(-moveSpeed, 0, 0);
        }
        */

        transform.position = transform.position + (Vector3.forward * moveSpeed)
        * Time.deltaTime;

        if (Input.GetKeyDown("space") && IsGrounded()) // jump up
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
