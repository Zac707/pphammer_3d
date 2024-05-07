using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammern : MonoBehaviour
{
    public bool hammeractive = false;
    public float hammertime = 1f;
    public GameObject Hammer;
    public GameObject Hindernis;
    RemovableBlock removableblock;
    [SerializeField] LayerMask layerMask;
    public AudioSource jackhammer;

    // Start is called before the first frame update
    void Start()
    {
        removableblock = Hindernis.GetComponent<RemovableBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hitinfo, 20f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hitinfo.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (hammeractive == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Hammeractivated();
                }
            }

            if (hammeractive == true)
            {
                hammertime -= Time.deltaTime;

                if (hammertime <= 0f)
                {
                    Hammerdeactivated();
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 20f, Color.red);
            Debug.Log("Did not Hit");
        }
    }

    private void Hammeractivated()
    {
        hammertime = 1f;
        hammeractive = true;
        Hammer.SetActive(true);
        jackhammer.Play();
    }

    private void Hammerdeactivated()
    {
        hammertime = 1f;
        hammeractive = false;
        Hammer.SetActive(false);
        if (removableblock != null)
        {
            removableblock.remove = true;
        }
        jackhammer.Stop();
    }
}
