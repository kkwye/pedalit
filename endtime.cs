using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endtime : MonoBehaviour
{
    public float final;
    public Text finalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        final = timer.timerHold;
        finalTime.text = final.ToString("f2");
    }
}
