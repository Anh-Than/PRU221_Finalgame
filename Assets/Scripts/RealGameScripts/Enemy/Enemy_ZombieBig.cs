using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy_ZombieBig : Enemy
{
    public Animator animator;
    void Start()
    {
             
    }
    void Update()
    {
        if (!detectedTower)
        {
            Move();
            animator.Play("RacconWalk");
        }
    }

    public override void InflictDamage()
    {
        if (detectedTower != null)
        {
            bool towerDied = detectedTower.LoseHealth(detectedTower.health);

            if (towerDied)
            {
                detectedTower = null;
                StopCoroutine(attackOrder);
            }
        }
    }

    IEnumerator Attack()
    {
        animator.Play("RacconAttack");
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
