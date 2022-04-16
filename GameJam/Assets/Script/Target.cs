using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Playerbullet")
        {
           Hit(damage: 1);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        Debug.Log("Target Take Damage");
    }
}
