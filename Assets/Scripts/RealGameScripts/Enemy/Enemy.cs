using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    public int health = 0;
    public int damage = 0;
    public float speed = 0f;
    public float attackInterval = 0f;
    public Coroutine attackOrder;
    public Tower detectedTower;

    void Start()
    {
    }

    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void LoseHealth(int damage)
    {
        //Decrease health value
        health -= damage;
        //Blink Red animation
        StartCoroutine(BlinkRed());
        //Check if health is zero => destroy enemy
        if (health <= 0)
        {
            ScoreSystem.instance.GainScore(1);
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkRed()
    {
        //Change the spriterendere color to red
        GetComponent<SpriteRenderer>().color = Color.red;
        //Wait for really small amount of time 
        yield return new WaitForSeconds(0.2f);
        //Revert to default color
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Attack()
    {
        //Wait attackInterval 
        yield return new WaitForSeconds(attackInterval);
        //Attack Again
        attackOrder = StartCoroutine(Attack());
    }

    public virtual void InflictDamage()
    {
        if (detectedTower != null)
        {
            bool towerDied = detectedTower.LoseHealth(damage);

            if (towerDied)
            {
                detectedTower = null;
                StopCoroutine(attackOrder);
            }
        }
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
