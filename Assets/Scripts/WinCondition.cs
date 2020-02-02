using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    int playerCount = 0;
    public bool win = false;

    public string[] messages;
    public string[] colors;

    string color;

    public Text redText;
    public Text blueText;

    Color purple = new Color(0.5f, 0, 1);
    Color red = new Color(1, 0, 0);
    Color blue = new Color(0, 0, 1);

    public float timeToWait;

    float elapsedTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
        }

        if (playerCount == 2 && win == false)
        {
            Debug.Log("You win!");
            win = true;

            for(int i = 0; i < messages.Length; i++)
            {
                Debug.Log(messages[i] + colors[i]);
                color = colors[i];
                if (color == "red")
                {
                    redText.color = red;
                    redText.text = messages[i];
                }
                else if (color == "blue")
                {
                    blueText.color = blue;
                    blueText.text = messages[i];
                }
                else if (color == "purple")
                {
                    redText.color = purple;
                    blueText.color = purple;
                    redText.text = messages[i];
                    blueText.text = messages[i];
                }

                elapsedTime = 0;
                while (elapsedTime < timeToWait)
                {
                    elapsedTime += Time.deltaTime;
                }

                redText.text = "";
                blueText.text = "";
            }
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
