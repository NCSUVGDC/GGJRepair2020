using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazeScript : MonoBehaviour
{
    public BoxCollider bc;
    int count = 0;
    public MeshRenderer mr;
    public Material activeMat;
    public Material inactiveMat;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spotlight"))
        {
            //Debug.Log("spotlight collided");
            count++;

            if (!bc.isTrigger)
            {
                bc.isTrigger = true;
                mr.material = inactiveMat;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spotlight"))
        {
            //Debug.Log("spotlight removed");
            count--;
        }

        if (count == 0)
        {
            bc.isTrigger = false;
            mr.material = activeMat;
        }
    }
}
