using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Bot_Handle : MonoBehaviour
{
    private Transform bot_transform;

    public void Init(Transform t){
        bot_transform = t;
    }
    public Transform GetTransform(){
        return bot_transform;
    }
}
