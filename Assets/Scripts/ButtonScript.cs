using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public bool pressed = false;
    int bodies = 0;

    // Update is called once per frame
    void Update()
    {
        if (bodies == 0)
        {
            pressed = false;
        } else
        {
            pressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bodies++;
            if (bodies == 1)
            {
                FindObjectOfType<AudioManager>().Play("Buttons");
            }
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bodies--;
        }
    }
}
