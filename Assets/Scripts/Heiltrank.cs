using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heiltrank : MonoBehaviour
{
    public int healAmount = 50;
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
                int playerHealth = gameManager.GetPlayerHealth();
                int maxHealth = gameManager.GetMaxHealth();
                int newHealth = playerHealth + healAmount;
                int finalHealth = Mathf.Min(newHealth, maxHealth);

                gameManager.SetPlayerHealth(finalHealth);
            }

            Destroy(gameObject);
        }
    }
}
