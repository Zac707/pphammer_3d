using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gefahr : MonoBehaviour
{
    public AudioSource swimming;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetPlayerInFire(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetPlayerInFire(true);
            swimming.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetPlayerInFire(false);
            swimming.Stop();
        }
    }
}
