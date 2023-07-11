using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy_ZombieBig : Enemy
{
    public float stopTime = 1f;
    public float moveTime = 5f;
    public bool isMoving = true;
    void Start()
    {
        Debug.Log("Zombie Big");
        StartCoroutine(MoveInterval());
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }
    //Big zombie rest for 1s
    IEnumerator MoveInterval()
    {
        isMoving = true;
        yield return new WaitForSeconds(moveTime);
        isMoving = false;
        yield return new WaitForSeconds(stopTime);
        StartCoroutine(MoveInterval());
    }
}
