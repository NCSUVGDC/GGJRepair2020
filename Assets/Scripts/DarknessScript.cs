using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScript : MonoBehaviour
{
    public BoxCollider bc;
    int lightCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spotlight")
        {
            Debug.Log("Light shined");
            lightCount++;
        }
        bc.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spotlight")
        {
            Debug.Log("Light removed");
            lightCount--;
        }

        if (lightCount == 0)
        {
            bc.enabled = true;
        }
    }

}
