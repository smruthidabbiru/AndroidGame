using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float RemainingTime = 0.0f;
    public int StartTarget = 10;
    int increment = 0;
    public Text DiamondText;
    public Text TimerText;
    void Start()
    {
        DiamondText.text = GameController.Diamonds.ToString() + " / " + StartTarget.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        RemainingTime -= Time.deltaTime;
        TimerText.text = Convert.ToInt32(RemainingTime).ToString();
        if(GameController.Diamonds == StartTarget)
        {
            RemainingTime += 180.0f;
            increment += 5;
            SetTarget();
            GameController.Bullets = GameController.Bullets + GameController.Yellow * 3;
            GameController.Yellow = 0;
        }
        if(RemainingTime <= 0)
        {
            GameController.Bullets = 0;
        }
    }
    void SetTarget()
    {
        StartTarget = StartTarget + 10 + increment;
    }
    private void LateUpdate()
    {
        DiamondText.text = GameController.Diamonds.ToString() + " / " + StartTarget.ToString();
    }
}
