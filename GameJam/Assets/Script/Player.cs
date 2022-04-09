using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int startHp;
    int hp;
    public float bullet_Cooldown;
    float bullet_Timer;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        bullet_Timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet" && bullet_Timer <= 0)
        {
            hp -= 1;
            print(hp);
            bullet_Timer = bullet_Cooldown;
        }
    }
}
