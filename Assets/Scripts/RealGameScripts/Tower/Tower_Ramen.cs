using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Ramen : Tower
{
    public LayerMask enemyLayerMask;
    public bool hasEnemy = false;
    public bool isShooting = false;
    public Animator animator;
    public Transform shootPoint;

    public GameObject prefab_shootItem;

    public int damage;
    protected override void Start()
    {
    }

    private void Update()
    {
        CheckEnemyInRange();
        if (!hasEnemy)
        {
            animator.Play("RamenIdle");
        }
        else if (hasEnemy)
        {

            animator.Play("RamenShoot");
        }
    }

    private void CheckEnemyInRange()
    {
        if (Physics2D.Raycast(transform.position, transform.right, 100, enemyLayerMask))
        {
            hasEnemy = true;
        }
        else
        {
            hasEnemy = false;
        }
    }

    public void Shoot()
    {
        if (hasEnemy)
        {
            ShootItem();
        }

    }

    //Shoot an item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, shootPoint);
        shotItem.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //Set its values  
        shotItem.GetComponent<ShootItem>().Init(damage);
    }

}
