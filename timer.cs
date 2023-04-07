using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text timerText;
    public static float timerHold;
    public float time;
    public float startTime;
    public bool end = false;

    void Start()
    {
        // startTime = timerHold;
        //DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            time = 0; 
        }
        else
        {
            time = timerHold;
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float t = Time.time - startTime;
        timerHold = t;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        */

        if (!end)
        {
            time = time + Time.deltaTime;
            timerHold = time;
            timerText.text = time.ToString("f2");
        }
        

        if (SceneManager.GetActiveScene().buildIndex == 4 && !end)
        {
            timerHold = time;
            end = true;
        }
    }
}
