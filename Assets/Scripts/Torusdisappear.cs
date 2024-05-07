using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppotion2 : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    public GameObject potion;
    Jumppotion jumppotion;
    // Start is called before the first frame update
    void Start()
    {
        jumppotion = potion.GetComponent<Jumppotion>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumppotion.potionactivated == true)
        {
            meshRenderer.enabled = false;
            meshCollider.enabled = false;
        }

    }
}
