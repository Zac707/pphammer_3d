using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schluessel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameManager.instance;

            if (gameManager != null)
            {
                gameManager.AddToInventory(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
