using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableBlock : MonoBehaviour
{
    public float RespawnTime = 20f;
    public bool remove = false;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remove == true)
        {
            RespawnTime -= Time.deltaTime;
            meshRenderer.enabled = false;
            meshCollider.enabled = false;

            if (RespawnTime <= 0f)
            {
                RespawnBlock();
                
            }
        }
    }
    
    private void RespawnBlock()
    {
        remove = false;
        meshRenderer.enabled = true;
        meshCollider.enabled = true; 
        RespawnTime = 20f;
    }
}
