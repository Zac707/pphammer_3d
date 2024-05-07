using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public GameObject keyObject; // Reference to the key object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameManager.instance;

            if (gameManager != null && keyObject != null)
            {
                if (gameManager.IsInInventory(keyObject))
                {
                    gameManager.RemoveFromInventory(keyObject);

                    Destroy(gameObject);
                }
            }
        }
    }
}
