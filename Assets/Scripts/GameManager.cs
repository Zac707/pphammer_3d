using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public static GameManager instance;
    public Text healthText;
    public int health = 100;
    public int maxHealth = 100;
    public float damageInterval = 0.2f; 
    private float damageTimer = 0f;
    private bool isPlayerInFire = false;
    public Text timerText;
    public List<GameObject> inventory;
    public Text inventoryText;
    public string targetSceneName;
    public string targetSceneName2;

    void Awake()
    { 
            if (instance == null)
                {
                    instance = this;
                }
            else if (instance != this)
                {
                    Destroy(gameObject);
                }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateHealthText();
    }

    private void Update()
    {
        if (isPlayerInFire)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                ReduceHealth(5);
                damageTimer = 0f;
            }
        }
        UpdateInventoryText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void AddToInventory(GameObject item)
    {
        inventory.Add(item);
        UpdateInventoryText();
    }

     public bool IsInInventory(GameObject item)
        {
            foreach (GameObject inventoryItem in inventory)
            {
                if (inventoryItem == item)
                {
                    return true;
                }
            }
            return false;
        }

    private void UpdateInventoryText()
        {
            string inventoryString = "";

            foreach (GameObject item in inventory)
            {
                inventoryString += item.name + " ";
            }

            if (inventoryText != null)
            {
                inventoryText.text = inventoryString;
            }
        }

    public void RemoveFromInventory(GameObject item)
    {
        inventory.Remove(item);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateHealthText()
        {
            healthText.text = "Health: " + health;
        }

    public void UpdateTimerText(float time)
    {
        int seconds = Mathf.FloorToInt(time);
        timerText.text = "Zeit: " + seconds.ToString();
    }

    

    public void ReduceHealth(int amount)
    {
        health -= amount;
        UpdateHealthText();

        if (health <= 0)
        {
            Sterben();
        }
    }

    public void Sterben()
    {
        Debug.Log("Spieler ist gestorben");
        health = maxHealth;
        UpdateHealthText();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level01")
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else if (currentScene.name == "Level02")
        {
            SceneManager.LoadScene(targetSceneName2);
        }
    }

    public void SetPlayerInFire(bool value)
    {
        isPlayerInFire = value;
    }

    public int GetPlayerHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetPlayerHealth(int newHealth)
    {
        health = Mathf.Clamp(newHealth, 0, maxHealth);
        UpdateHealthText();
    }

   
}

