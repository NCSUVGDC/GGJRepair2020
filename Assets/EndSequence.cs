using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSequence : MonoBehaviour
{
    public LevelLoader lvlld;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            lvlld.LoadNextLevel(0);
        }
    }
}
