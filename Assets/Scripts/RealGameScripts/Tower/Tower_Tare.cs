using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower_Tare : Tower
{
    public int shrinkTime;
    public Enemy enemyDetected;
    public Animator animator;
    public bool isEating;
    public bool hasEaten;

    protected override void Start()
    {
        base.Start();
        hasEaten = false;
    }

    public void Update()
    {
        if (!isEating)
        {
            animator.Play("TareIdle");
        }else if(isEating)
        {
            animator.Play("TareEat");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasEaten)
        {
            return;
        }
        if(collision.tag == "Enemy")
        {            
            hasEaten = true;
            StartCoroutine(EndEating());
            enemyDetected = collision.GetComponent<Enemy>();
            collision.GetComponent<Shrinking>().ScaleToTarget(new Vector3(0.1f, 0.1f, 0.1f), shrinkTime);
        }
    }

    public void InflictDamage()
    {
        if(enemyDetected != null)
        {
            enemyDetected.LoseHealth(enemyDetected.health);
        }
    }

    IEnumerator EndEating()
    {
        isEating = true;
        yield return new WaitForSeconds(3);
        isEating = false;
        Die();
    }
}
