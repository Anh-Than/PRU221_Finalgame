using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBrick : MonoBehaviour
{
    Rigidbody2D rg;
    float power;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        rg.bodyType = RigidbodyType2D.Dynamic;
        rg.AddForce(new Vector2(-1f,1f), ForceMode2D.Impulse);
    }
}
