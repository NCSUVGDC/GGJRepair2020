using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    int playerCount = 0;
    public bool win = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
        }

        if (playerCount == 2)
        {
            Debug.Log("You win!");
            win = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!win && other.CompareTag("Player"))
        {
            playerCount--;
        }
    }
}
