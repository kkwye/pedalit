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

    // new - restart level if not complete within 60s
    [SerializeField] public float levelRestartTimer;
    

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {



        timeStart = timeStart + Time.deltaTime;

        levelRestartTimer = levelRestartTimer - Time.deltaTime;
        /*
        if (levelRestartTimer <= 0)
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(5);
            
            }
           
        }
        */

        if (Input.GetKeyDown("space") && grounded) // jump up
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpSound.Play();
        }



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

        

        if (sp.IsOpen)
        {
            try
            {
                // When left button is pushed
                if (sp.ReadByte() >= 50)
                {
                    print(sp.ReadByte());
                    
                    //transform.Translate(Vector3.left * Time.deltaTime * 5);

                    // here: rb.velocity = new Vector3(0, 0, 5);

                    // new

                    /*
                    if (timerSwitch)
                    {
                        timerSwitch = false;
                        // stop timer
                    }
                    if (!timerSwitch)
                    {
                        timerSwitch = true;
                        // start timer
                    }
                    */

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
                    

                    // send speed to rb
                    // rb.velocity = new Vector3(0, 0, timerSpeed);
                    // transform.position = transform.position + (Vector3.forward * moveSpeed * Time.deltaTime);


                    // reset timer 
                    timeStart = 0f;
                    

                    


                }
                // When right button is pushed
            }
            /*
            if (sp.ReadByte() >= 50)
            {
                print(sp.ReadByte());
                transform.Translate(Vector3.right * Time.deltaTime * 5);
            }
            */
            catch (System.Exception)
            {

            }

        }


        transform.position = transform.position + (Vector3.forward * moveSpeed)
        * Time.deltaTime;


    }
    /*
   bool IsGrounded()
   {

       Debug.Log(groundCheck.position);
       return Physics.CheckSphere(groundCheck.position, 0.1f, ground);

   }
    */

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
