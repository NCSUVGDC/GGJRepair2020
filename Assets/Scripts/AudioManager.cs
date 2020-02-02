using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    public void play(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (string.Equals(sounds[i].name, name))
            {
                sounds[i].source.Play();
                return;
            }
        }

        Debug.LogWarning("No sound of name: " + name + " found");
    }
}
