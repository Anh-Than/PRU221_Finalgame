using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Tilemaps;

public class Tower_ChaShu : Tower
{
    public Animator animator;
    Enemy enemy;
    public bool hasEnemy;
    public float flySpeed;
    public int damage;
    public int dizzyTime;
    public bool readyToCharge;
    public bool hasCollided;
    public int aliveTime;

    protected override void Start()
    {
        StartCoroutine(AliveTime());
        hasEnemy = false;
        hasCollided = false;
        StartCoroutine(DelayBeforeCharge());
        animator.Play("ChaShuFire");
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasEnemy && readyToCharge)
        {
            FlyForward();
        }else if(hasEnemy)
        {
            animator.Play("ChaShuDizzy");
        }
    }

    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasCollided)
        {
            return;
        }
        if(collision.tag == "Enemy")
        {
            hasEnemy=true;
            hasCollided=true;
            enemy = collision.GetComponent<Enemy>();
            enemy.LoseHealth(damage);
            StartCoroutine(DizzyTime());
        }
    }

    IEnumerator DizzyTime()
    {
        yield return new WaitForSeconds(dizzyTime);
        Die();
    }

    IEnumerator DelayBeforeCharge()
    {
        readyToCharge = false;
        yield return new WaitForSeconds(0.5f);
        readyToCharge=true;
        FindObjectOfType<PlaceTower>().RevertCellState(cellPosition);
    }

    IEnumerator AliveTime()
    {
        yield return new WaitForSeconds(aliveTime);
        Die();
    }
}
