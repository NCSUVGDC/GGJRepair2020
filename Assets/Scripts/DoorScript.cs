using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public ButtonScript button;

    public float distance = 10f;
    public float speed = 10f;

    private Vector3 endpos;
    private Vector3 startpos;
    // Start is called before the first frame update

    void Start()
    {
        endpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.pressed)
        {
            Debug.Log("button pressed");
            transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, startpos, speed * Time.deltaTime);
        }
    }
}
