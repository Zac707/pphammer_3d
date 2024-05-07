using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform Ziel;
    public GameObject Player;
    public AudioSource beam;

    void Start()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = Ziel.transform.position;

            beam.Play();
        }
         
    }
  }


