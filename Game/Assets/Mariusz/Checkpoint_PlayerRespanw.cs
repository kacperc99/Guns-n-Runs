using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_PlayerRespanw : MonoBehaviour
{
    [SerializeField]private Vector2 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetKeyDown(KeyCode.L))
       {
        transform.position = checkpoint;
       } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Checkpoint"){
            //condition for change///

            //change
             checkpoint = col.transform.position;
        }
    }

    
}
