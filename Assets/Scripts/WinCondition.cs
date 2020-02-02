using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    int playerCount = 0;
    public bool win = false;
    public bool conversationDone = false;

    public string[] messages;
    public string[] colors;

    string color;

    public Text redText;
    public Text blueText;

    Color purple = new Color(0.5f, 0, 1);
    Color red = new Color(1, 0, 0);
    Color blue = new Color(0, 0, 1);

    int currentIndex = 0;

    public CanvasGroup fade1;
    public CanvasGroup fade2;

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
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!win && other.CompareTag("Player"))
        {
            playerCount--;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && win)
        {
            redText.text = "";
            blueText.text = "";
            if (currentIndex < messages.Length)
            {
                Debug.Log(messages[currentIndex] + colors[currentIndex]);
                color = colors[currentIndex];
                if (color == "red")
                {
                    redText.color = red;
                    redText.text = messages[currentIndex];
                }
                else if (color == "blue")
                {
                    blueText.color = blue;
                    blueText.text = messages[currentIndex];
                }
                else if (color == "purple")
                {
                    redText.color = purple;
                    blueText.color = purple;
                    redText.text = messages[currentIndex];
                    blueText.text = messages[currentIndex];
                }

                currentIndex++;
            } else
            {
                conversationDone = true;
            }
            
            
        }
    }



}
