using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineScript : MonoBehaviour
{
    public ParticleSystem ps;
    public float killTime = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Blades")
        {
            ps.Play();
            Destroy(this.gameObject, killTime);
            FindObjectOfType<AudioManager>().Play("Blades");
        }
    }
}
