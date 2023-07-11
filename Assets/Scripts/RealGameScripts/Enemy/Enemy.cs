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
    Coroutine attackOrder;
    //Tower detectedTower;

    public bool towerDetected = false;
    void Start()
    {
    }

    void Update()
    {
        if (!towerDetected)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void LoseHealth()
    {
        //Decrease health value
        health--;
        //Blink Red animation
        StartCoroutine(BlinkRed());
        //Check if health is zero => destroy enemy
        if (health <= 0)
        {
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

    //public void InflictDamage()
    //{
    //    if (detectedTower != null)
    //    {
    //        bool towerDied = detectedTower.LoseHealth(damage);

    //        if (towerDied)
    //        {
    //            detectedTower = null;
    //            StopCoroutine(attackOrder);
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
