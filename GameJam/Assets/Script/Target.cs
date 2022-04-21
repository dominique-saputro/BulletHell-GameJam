using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float startHealth;
    float health;
    public float speed;
    public Vector2 velocity;

    public bool isEnemyDead = false;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            isEnemyDead = true;
        }

        transform.Translate(velocity * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Playerbullet")
        {
           Hit(damage: 1);
        }

        if(collision.tag == "Wall")
        {
            velocity = velocity * -1;
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        Debug.Log(health);
        healthBar.fillAmount = ((float)health / (float)startHealth) * 1f;
    }
}
