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
                
                
            } else if (isRed)
            {
                redText.color = red;
                redText.text = textToType;
            } else if (isBlue)
            {
                blueText.color = blue;
                blueText.text = textToType;
            }

            played = true;

            StartCoroutine("WaitThenClear");
        }
    }

    IEnumerator WaitThenClear()
    {
        yield return new WaitForSecondsRealtime(5);
        redText.text = "";
        blueText.text = "";
    }
}
