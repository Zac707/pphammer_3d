using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  SchatzEinsammeln : MonoBehaviour
{
    public int scoreToAdd = 100;
    public AudioSource coin;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            coin.Play();
            Destroy(gameObject);
            GameManager.instance.AddScore(scoreToAdd);
            
        }
    }
}
