using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class ghostmovement : MonoBehaviour
{
    Rigidbody rb;
    public float ghostSpeed = 0.5f;
    
    // new - restart level if not complete within 60s
    [SerializeField] public float levelRestartTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.forward * ghostSpeed)
        * Time.deltaTime;
    }
}

