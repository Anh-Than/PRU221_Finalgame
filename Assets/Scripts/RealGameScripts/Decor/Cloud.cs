using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    float x;
    void Start()
    {
        x = transform.position.x;
        if(x > -1.5f)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
