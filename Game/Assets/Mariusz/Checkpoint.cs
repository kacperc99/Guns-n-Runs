using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos(){
        Gizmos.color = new Color(0.8f,0.0f,1.0f,1.0f);
        Gizmos.DrawLine(transform.position- transform.up*10,transform.position+ transform.up*10);
    }
}
