using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public int index = 1;
    public bool isSequenceRandom;
    public bool spawningAutomatically;

    BulletSpawnData GetSpawnData()
    {
        return spawnDatas[index];
    }

    float timer;
    float[] rotations;


    // Start is called before the first frame update
    void Start()
    {
        timer = GetSpawnData().cooldown;
        rotations = new float[GetSpawnData().bullet_NumberCount];
        if(!GetSpawnData().isRandom)
        {
            DistributedRotations();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawningAutomatically)
        {
        if( timer <= 0 )
        {
            SpawnBullets();
            timer = GetSpawnData().cooldown;
            if (isSequenceRandom)
            {
                index = Random.Range(0, spawnDatas.Length);
            } else 
            {
                index += 1;
                if ( index >= spawnDatas.Length) index = 0;
            }
            rotations = new float[GetSpawnData().bullet_NumberCount];
            
        }
        timer -= Time.deltaTime;
        }
    }

    public float[] RandomRotations()
    {
        for(int i = 0; i < GetSpawnData().bullet_NumberCount; i++)
        {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int i = 0; i < GetSpawnData().bullet_NumberCount; i++)
        {
            var fraction = (float)i / (float)GetSpawnData().bullet_NumberCount - 1;
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionofDifference = fraction * difference;
            rotations[i] = fractionofDifference + GetSpawnData().minRotation;
        }

        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullets()
    {
        rotations = new float[GetSpawnData().bullet_NumberCount];
        if(GetSpawnData().isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[GetSpawnData().bullet_NumberCount];
        for (int i = 0; i < GetSpawnData().bullet_NumberCount; i++)
        {
            spawnedBullets[i] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[i]==null)
            {
                 spawnedBullets[i] = Instantiate(GetSpawnData().bullet_Resource, transform.position, transform.rotation);
                 BulletManager.bullets.Add(spawnedBullets[i]);
            } else
            {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            }
           
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bullet_Speed;
            b.velocity = GetSpawnData().bullet_Velocity;
            if (!GetSpawnData().isParent) spawnedBullets[i].transform.SetParent(null);
        }
        return spawnedBullets;
    }
}
