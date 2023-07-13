using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zombie : Enemy
{
    public Animator animator;
    bool isEating = false;
    void Start()
    {

    }
    void Update()
    {
        if (!detectedTower)
        {
            Move();
            animator.Play("MouseWalk");
        }
    }

    IEnumerator Attack()
    {
        if(!isEating)
        {
            animator.Play("MouseRiseUp");
            isEating = true;
        }
        if(isEating)
        {
            animator.Play("MouseEat");
        }
        //Wait attackInterval 
        yield return new WaitForSeconds(attackInterval);
        InflictDamage();
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
