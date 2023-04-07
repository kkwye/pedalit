using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 1;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] float divider = 8;
    public bool grounded = false;
    SerialPort sp = new SerialPort("/dev/cu.usbmodem101", 9600);

    // new stuff - sensor to speed
    public float timeStart = 0f;
    public float timeSince = 0f;
    [SerializeField] public float timerSpeed = 0f;


   
    void Start()
    {

        // Debug.Log("Hello from start");
        rb = GetComponent<Rigidbody>();
        Debug.Log(Physics.CheckSphere(groundCheck.position, 0.1f, ground));
        Debug.Log(groundCheck.position);
        Debug.Log("starting");
        levelRestartTimer = 200f; 
        sp.Open();
        sp.ReadTimeout = 100;
    }

    void Update()
    {



        timeStart = timeStart + Time.deltaTime;

        levelRestartTimer = levelRestartTimer - Time.deltaTime;
    

        if (Input.GetKeyDown("space") && grounded) // jump up
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpSound.Play();
        }

        if (sp.IsOpen)
        {
            try
            {
                // When left button is pushed
                if (sp.ReadByte() >= 50)
                {
                    print(sp.ReadByte());
                   
                    // stop timer
                    timeSince = timeStart;
                    Debug.Log("time since last sensed: " + timeSince);
                    
                    
                    // calculate speed
                    if (timeSince > 0.5f)
                    {
                        timerSpeed = divider / timeSince;
                        Debug.Log("speed: " + timerSpeed);
                        moveSpeed = timerSpeed;
                    }
                    
                   timeStart = 0f;

                }
            }
           
            catch (System.Exception)
            {

            }

        }


        transform.position = transform.position + (Vector3.forward * moveSpeed)
        * Time.deltaTime;


    }
  
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
