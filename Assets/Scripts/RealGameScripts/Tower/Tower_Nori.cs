using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Nori : Tower
{
    public float mediumScale;
    public float smallScale;

    int threshold;

    protected override void Start()
    {
        threshold = Mathf.RoundToInt(health / 2);
        Debug.Log(threshold);
    }
    void Update()
    {
        if(health > 2 && health <= threshold) {
            transform.localScale = new Vector3(mediumScale, mediumScale, mediumScale);
        }else if (health <= 2)
        {
            transform.localScale = new Vector3(smallScale, smallScale, smallScale);
        }
    }
}
