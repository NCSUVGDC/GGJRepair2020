using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazeScript : MonoBehaviour
{
    public BoxCollider bc;
    int count = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spotlight"))
        {
            Debug.Log("spotlight collided");
            count++;
        }

        bc.isTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spotlight"))
        {
            Debug.Log("spotlight removed");
            count--;
        }

        if (count == 0)
        {
            bc.isTrigger = false;
        }
    }
}
