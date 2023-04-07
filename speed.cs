using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    public PlayerMovement target;
    public ghostmovement ghost;
    public float max = 0f;
    public Text speedPrompt;

    public Color myRed = new Color32(237, 114, 71, 255);
    public Color myYellow = new Color32(250, 179, 0, 255);
    public Color myGreen = new Color32(112, 199, 128, 255);

    /*
    [SerializeField] public float minSpeedAngle = 0f;
    [SerializeField] public float maxSpeedAngle = 0f;
    */
    public float playerSpeed = 0f;

    public RectTransform arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = target.moveSpeed;
        if (arrow != null)
        {
            if (playerSpeed < 1.5)
            {
                arrow.localEulerAngles =
                new Vector3(0, 0, 180 - playerSpeed * 120);
            }
            else
            {
                arrow.localEulerAngles =
                new Vector3(0, 0, 0);
            }
       

        }
        
        if (playerSpeed < 0.4)
        {
            speedPrompt.text = "Too slow!";
            speedPrompt.color = myRed;
        }
        if (playerSpeed > 0.4 && playerSpeed < 1.1)
        {
            speedPrompt.text = "Good work!";
            speedPrompt.color = myYellow;
        }
        if (playerSpeed > 1.1)
        {
            speedPrompt.text = "Super!";
            speedPrompt.color = myGreen;
        }
    }
}

// speed is between 0 and 1.5 -> angle is 180 - speed * 120