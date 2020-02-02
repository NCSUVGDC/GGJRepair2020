using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{

    public ButtonScript button;

    public float distance = 5f;
    public float speed = 20f;

    public float killTime = 0.5f;

    private Vector3 endpos;

    bool cut = false;

    // Start is called before the first frame update
    void Start()
    {
        endpos = transform.position - distance * transform.up;

    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
            cut = true;
        }

        if (cut)
        {
            if (Vector3.Magnitude(transform.position - endpos) > 0.1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Vines")
        {
            Destroy(other.gameObject, killTime);
            FindObjectOfType<AudioManager>().Play("Blades");
            Destroy(this.gameObject, killTime);
        }
    }
}
