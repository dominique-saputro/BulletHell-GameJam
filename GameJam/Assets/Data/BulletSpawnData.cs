using UnityEngine;

[CreateAssetMenu(fileName = "BulletSpawnData", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]
public class BulletSpawnData : ScriptableObject 
{
     public GameObject bullet_Resource;
    public float minRotation;
    public float maxRotation;
    public int bullet_NumberCount;
    public bool isRandom;
    public bool isParent = true;
    public float cooldown;
    public float bullet_Speed;
    public Vector2 bullet_Velocity;
}
