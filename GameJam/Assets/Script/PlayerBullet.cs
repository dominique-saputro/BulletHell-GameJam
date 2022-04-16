using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;
    public float lifeTime;
    public float damage;
    float timer; //Time until bullet is destroyed

    // Start is called before the first frame update
    void Start()
    {
        timer = lifeTime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        timer -= Time.deltaTime;

        if (timer <= 0)  Destroy(gameObject);
    }
}
