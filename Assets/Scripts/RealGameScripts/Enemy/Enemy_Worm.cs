using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Worm : Enemy
{
    public Animator animator;
    void Start()
    {
             
    }
    private void Update()
    {
        if (!detectedTower)
        {
            Move();
            animator.Play("WormWalk");
        }
    }

    IEnumerator Attack()
    {
        animator.Play("WormAttack");
        //Wait attackInterval 
        yield return new WaitForSeconds(attackInterval);
        //Attack Again
        attackOrder = StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
            return;

        if (collision.tag == "Tower")
        {
            Debug.Log("has tower");
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }
    }
}
