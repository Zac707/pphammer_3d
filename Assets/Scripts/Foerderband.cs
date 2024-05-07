using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foerderband : MonoBehaviour
{
    public float strength = 5f; // Adjust the strength as desired
    private Transform target; // Child object to indicate the direction

    void Start()
    {
        target = transform.GetChild(0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Move(other.gameObject);
        }
    }

    private void Move(GameObject objectToMove)
    {
        Vector3 dir = GetDirection(objectToMove.transform.position, target.position);
        objectToMove.GetComponent<Rigidbody>().AddForce(dir * strength, ForceMode.Impulse);
    }

    private Vector3 GetDirection(Vector3 from, Vector3 to)
    {
        Vector3 dir = (to - from).normalized;
        return dir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
