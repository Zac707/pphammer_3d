using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelwechsel : MonoBehaviour
{
    public int level;
    public string targetSceneName;
    public string targetSceneName2;
    public AudioSource nextlvl;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level01")
        {
            level = 0;
        }
        else if (currentScene.name == "Level02")
        {
            level = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextlvl.Play();
            if (level == 0)
            {
                SceneManager.LoadScene(targetSceneName);
            }
            if (level == 1)
            {
                SceneManager.LoadScene(targetSceneName2);
            }
        }
    }
}
