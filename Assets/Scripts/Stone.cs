using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody stoneRigidbody;
    private bool ausgeloest = false;

    // Start is called before the first frame update
    void Start()
    {
        stoneRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stoneRigidbody.useGravity = true;
            ausgeloest = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (stoneRigidbody.useGravity == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager gameManager = GameManager.instance;

                if (gameManager != null)
                {
                    gameManager.Sterben();
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (ausgeloest = true)
        {
            if (stoneRigidbody != null && stoneRigidbody.velocity.magnitude < 0.1f)
            {
                if (collision.gameObject.CompareTag("plane"))
                {
                    stoneRigidbody.isKinematic = true;
                    stoneRigidbody.useGravity = false;
                }
            }
        }
    }
}
