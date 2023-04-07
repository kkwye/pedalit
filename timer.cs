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
