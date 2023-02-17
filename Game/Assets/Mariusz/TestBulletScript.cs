using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletScript : MonoBehaviour
{
    public float Speed = 0.03f;
    public float dirction_degree = 0;
    public float life_time = 3.0f;
    public float random_direction_component = 0.0f; 
    public float constant_direction_component = 0.0f; 

    void Start()
    {
   
    }

    void FixedUpdate()
    {
        life_time -= 1.0f/60.0f;
        if(life_time < 0)
            Destroy(gameObject);
        Vector2 dir_v = new Vector2(Mathf.Cos(dirction_degree),Mathf.Sin(dirction_degree));
        transform.position = transform.position + (new Vector3(dir_v.x,dir_v.y,0)*Speed)/60.0f;
        transform.rotation = Quaternion.EulerAngles(0,0,dirction_degree);


        dirction_degree += (Random.value-0.5f)*random_direction_component;
         dirction_degree += constant_direction_component/60.0f;
    }
}
