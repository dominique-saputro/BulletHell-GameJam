using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "bullet" || other.tag == "Playerbullet")
        {
            other.gameObject.SetActive(false);
        }
    }

}
