using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{
    //FIELDS
    //graphics (the sprite renderer)
    public Transform graphics;
    //damage
    public int damage;
    //speed
    public float flySpeed, rotateSpeed;

    //METHODS
    //Init
    public void Init(int dmg)
    {
        damage = dmg;
    }
    //Trigger with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().LoseHealth(damage);
            Destroy(gameObject);
        }
        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }
    //Handle rotation and flying
    void Update()
    {
        FlyForward();
        Rotate();
    }
    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }

    void Rotate()
    {
        graphics.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
