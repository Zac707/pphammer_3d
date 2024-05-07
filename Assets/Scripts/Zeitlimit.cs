using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeitlimit : MonoBehaviour
{
    public float timerDuration = 300f; 
    private float countdown; 

    private void Start()
    {
        countdown = timerDuration;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            GameManager.instance.Sterben();
            countdown = timerDuration;
        }
        GameManager.instance.UpdateTimerText(countdown);
    }
}

