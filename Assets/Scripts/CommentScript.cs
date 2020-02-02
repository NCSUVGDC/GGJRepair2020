using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentScript : MonoBehaviour
{

    public Text redText;
    public Text blueText;

    public string textToType;

    public bool isRed;
    public bool isBlue;

    Color purple = new Color(0.5f, 0, 1);
    Color red = new Color(1, 0, 0);
    Color blue = new Color(0, 0, 1);

    bool redRunning = false;
    bool blueRunning = false;
    bool purpleRunning = false;

    Coroutine redco;
    Coroutine blueco;
    Coroutine purpleco;

    public bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !played)
        {
            if (isRed && isBlue)
            {
                
                redText.color = purple;
                blueText.color = purple;
                redText.text = textToType;
                blueText.text = textToType;
                if (purpleRunning)
                {
                    StopCoroutine(purpleco);
                    purpleRunning = false;
                }
                FindObjectOfType<AudioManager>().Play("Notif1");
                FindObjectOfType<AudioManager>().Play("Notif2");
                purpleco = StartCoroutine(WaitThenClear(2));

            } else if (isRed)
            {
                redText.color = red;
                redText.text = textToType;

                if (redRunning)
                {
                    Debug.Log("stopping coroutine");
                    StopCoroutine(redco);
                    redRunning = false;
                }
                FindObjectOfType<AudioManager>().Play("Notif2");
                redco = StartCoroutine(WaitThenClear(0));
            } else if (isBlue)
            {
                blueText.color = blue;
                blueText.text = textToType;
                if (blueRunning)
                {
                    StopCoroutine(blueco);
                    blueRunning = false;
                }
                FindObjectOfType<AudioManager>().Play("Notif1");
                blueco = StartCoroutine(WaitThenClear(1));
            }

            played = true;

            
        }
    }

    IEnumerator WaitThenClear(int color)
    {
        
        
        if (color == 2)
        {
            purpleRunning = true;
            yield return new WaitForSeconds(5);
            redText.text = "";
            blueText.text = "";
            purpleRunning = false;
        } else if (color == 1)
        {
            blueRunning = true;
            yield return new WaitForSeconds(5);
            blueText.text = "";
            blueRunning = false;
        } else if (color == 0)
        {
            redRunning = true;
            Debug.Log("red is running");
            yield return new WaitForSeconds(5);
            redText.text = "";
            Debug.Log("red no longer running");
            redRunning = false;
        }
        
        
    }
}
