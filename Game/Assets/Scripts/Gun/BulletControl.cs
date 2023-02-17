using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float rangeX;
    public float rangeY;

    Vector3 spawnPos;
    private Vector2 distance;
    

    private void Start()
    {
        
        spawnPos = PlayerMovement.playerPos;
    }

    void Update()
    {

        DistanceCheck();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision != null)

        if(collision != null && collision.gameObject.tag == "Enemy")


        if(collision != null && collision.gameObject.tag == "Enemy")

        {
            GameObject.Destroy(gameObject);
        }
    }



    private void DistanceCheck()
    {
        distance.x = Mathf.Abs(transform.position.x - spawnPos.x);
        distance.y = Mathf.Abs(transform.position.y - spawnPos.y);

        if (distance.x > rangeX || distance.x < -rangeX)
        {
            GameObject.Destroy(gameObject);
        }
        if (distance.y > rangeY || distance.y < -rangeY)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
