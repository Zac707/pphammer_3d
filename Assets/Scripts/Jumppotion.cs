
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppotion : MonoBehaviour
{
    public float jumpPower = 5f;
    public float duration = 10f;
    public bool potionactivated = false;
    public GameObject Player;
    CharacterMove charactermove;
    private MeshRenderer meshRenderer;
    private CapsuleCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        charactermove = Player.GetComponent<CharacterMove>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (potionactivated)
        {
            duration -= Time.deltaTime;
            if (duration <= 0f)
            {
                DeactivateJumppowerup();
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Jumppowerup();
            meshRenderer.enabled = false;
            meshCollider.enabled = false;
            potionactivated = true;
            Debug.Log("Potion collected by player");
            
        }
    }

    private void Jumppowerup()
    {
        if (charactermove != null)
        {
            charactermove.jumpSpeed += jumpPower;
            
            Debug.Log("Jump power activated for player");
        }
    }

    private void DeactivateJumppowerup()
    {
        if (charactermove != null)
        {
            charactermove.jumpSpeed -= jumpPower;
            Debug.Log("Jump power deactivated for player");
        }
        duration = 10f;
        potionactivated = false;
    }
}


