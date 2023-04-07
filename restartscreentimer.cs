using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class restartscreentimer : MonoBehaviour
{
    [SerializeField] public float restartScreenTimer;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        restartScreenTimer = 3f; 
    }

    // Update is called once per frame
    void Update()
    {
        restartScreenTimer = restartScreenTimer - Time.deltaTime;
        timerText.text = restartScreenTimer.ToString("f0");
        
        if (restartScreenTimer <= 0)
        {

            SceneManager.LoadScene(1);
        }
    }
}
