using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotation : MonoBehaviour
{
    public ButtonScript button;

    public float rotationSpeed = 36f;
    public bool counterclockwise = true;

    bool soundPlaying = false;

    public Sound sound;

    void Awake()
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;

        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;

        sound.source.loop = sound.loop;
    }

    void FixedUpdate()
    {
        if (button.pressed)
        {
            if (!soundPlaying)
            {
                sound.source.Play();
                soundPlaying = true;
            }
            
            if (counterclockwise)
            {
                transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime, Space.Self);
            }
            else 
            {
                transform.Rotate(0, 0, -1 * rotationSpeed * Time.fixedDeltaTime, Space.Self);
            }
        } else
        {
            soundPlaying = false;
            sound.source.Stop();
        }
    }
}
