using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public bool isAlive = true;
    public int startHp;
    int hp;
    public float bullet_Cooldown;
    float bullet_Timer;

    public float fireRate;
    public Image healthBar;
    float currentFireRate;  
    public GameObject[] PlayerBullets;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
        currentFireRate = fireRate;
        
    }

    // Update is called once per frame
    void Update()
    {
        bullet_Timer -= Time.deltaTime;
        if(Input.GetMouseButton(0) || Input.GetAxisRaw("Fire1") > 0)
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet" && bullet_Timer <= 0)
        {
            hp -= 1;
            bullet_Timer = bullet_Cooldown;
            Debug.Log("Player HP: " + hp);
            healthBar.fillAmount = ((float)hp / (float)startHp) * 1f;
        }

        if(hp < 0)
        {   
            isAlive = false;
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        currentFireRate -= Time.deltaTime;
        if(currentFireRate < 0)
        {
            int r = Random.Range(0,PlayerBullets.Length);
            Instantiate(PlayerBullets[r], transform.position, transform.rotation);
            currentFireRate = fireRate;
        }

    }

}
