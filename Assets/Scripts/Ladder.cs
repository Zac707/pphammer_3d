using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public float climbSpeed = 5f; // Adjust the climbing speed as desired

    private bool isClimbing = false;
    private Rigidbody playerRigidbody;

    public AudioSource climb;

    private void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
            playerRigidbody.useGravity = false;
            climb.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
            playerRigidbody.useGravity = true;
            climb.Stop();
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");

            // Move the player up or down on the ladder
            Vector3 moveDirection = transform.up * verticalInput * climbSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(playerRigidbody.position + moveDirection);
        }
    }
}


