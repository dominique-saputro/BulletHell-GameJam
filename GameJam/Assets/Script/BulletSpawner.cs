using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bullet_Resource;
    public float minRotation;
    public float maxRotation;
    public int bullet_NumberCount;
    public bool isRandom;

    public float cooldown;
    float timer;
    public float bullet_Speed;
    public Vector2 bullet_Velocity;

    float[] rotations;


    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
        rotations = new float[bullet_NumberCount];
        if(!isRandom)
        {
            DistributedRotations();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( timer <= 0 )
        {
            SpawnBullets();
            timer =cooldown;
        }
        timer -= Time.deltaTime;
    }

    public float[] RandomRotations()
    {
        for(int i = 0; i < bullet_NumberCount; i++)
        {
            rotations[i] = Random.Range(minRotation, maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int i = 0; i < bullet_NumberCount; i++)
        {
            var fraction = (float)i / (float)bullet_NumberCount - 1;
            var difference = maxRotation - minRotation;
            var fractionofDifference = fraction * difference;
            rotations[i] = fractionofDifference + minRotation;
        }

        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullets()
    {
        if(isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[bullet_NumberCount];
        for (int i = 0; i < bullet_NumberCount; i++)
        {
            spawnedBullets[i] = Instantiate(bullet_Resource, transform);
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = bullet_Speed;
            b.velocity = bullet_Velocity;
        }
        return spawnedBullets;
    }
}
