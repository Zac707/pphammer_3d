using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float dangertime = 2f;
    public float hiddentime = 5f;
    public Transform danger;
    public Transform hidden;
    public bool spikesactivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spikesactivated == true)
        {
            dangertime -= Time.deltaTime;

            if(dangertime <= 0f)
            {
                DeactivateSpike();
            }
        }
        if (spikesactivated == false)
        {
            hiddentime -= Time.deltaTime;

            if (hiddentime <= 0f)
            {
                ActivateSpike();
            }
        }
    }

    private void DeactivateSpike()
    {
        this.gameObject.transform.position = hidden.transform.position;
        spikesactivated = false;
        dangertime = 2f;
    }

    private void ActivateSpike()
    {
        this.gameObject.transform.position = danger.transform.position;
        spikesactivated = true;
        hiddentime = 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetPlayerInFire(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetPlayerInFire(false);
        }
    }
}
