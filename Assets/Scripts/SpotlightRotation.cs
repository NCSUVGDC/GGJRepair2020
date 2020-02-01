using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotation : MonoBehaviour
{
    public ButtonScript button;

    public float rotationSpeed = 36f;
    public bool counterclockwise = true;
    
    void FixedUpdate()
    {
        if (button.pressed)
        {
            if (counterclockwise)
            {
                transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime, Space.Self);
            }
            else 
            {
                transform.Rotate(0, 0, -1 * rotationSpeed * Time.fixedDeltaTime, Space.Self);
            }
        }
    }
}
