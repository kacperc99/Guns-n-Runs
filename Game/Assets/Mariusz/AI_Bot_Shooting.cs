using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bot_Shooting : MonoBehaviour
{
    [SerializeField]private GameObject bulletObject; 
    private float shoot_timer;
     [SerializeField]private float shooting_interval = 2;// w sekundach
     [SerializeField]private float shooting_interval_rand_time = 2;// w sekundach
    private Transform target;
    void Start()
    {
        SetNewTime();
        target = GameObject.Find("Targett").transform;    
    }

    private void SetNewTime(){
        shoot_timer = shooting_interval*Random.value*shooting_interval_rand_time;
    }

    // Update is called once per frame
    void Update()
    {
        shoot_timer -= Time.deltaTime;
        if(shoot_timer <= 0){
            SetNewTime();
            if(bulletObject != null && target != null){
                GameObject newBullet = Instantiate(bulletObject);
                TestBulletScript tbs = newBullet.GetComponent<TestBulletScript>();
                Vector2 targPos = target.position;
                Vector2 myPos = transform.position;
                Vector2 diff = targPos - myPos;
                tbs.dirction_degree = Mathf.Atan2(diff.y,diff.x);
                newBullet.transform.position = transform.position;
            }
        }
    }
}
