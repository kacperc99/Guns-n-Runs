using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_AI : MonoBehaviour
{
    private GameObject AIHandleObject;
    private GameObject AIInstanceHandle;

    private Vector2 targetPosition;
    [SerializeField]private float Speed = 2.0f;
    [SerializeField]private float BotAvoidingImportance = 2.0f;
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;

    private Transform targett;
    void Start()
    {
        AIHandleObject = GameObject.Find("AI_HANDLE_OBJECT");
        if(AIHandleObject == null){
            AIHandleObject = new GameObject();
            AIHandleObject.name = "AI_HANDLE_OBJECT";
        }

        AIInstanceHandle = new GameObject(gameObject.name + "_HANDLE");
        AIInstanceHandle.transform.SetParent(AIHandleObject.transform,true);
        (AIInstanceHandle.AddComponent<Ai_Bot_Handle>()).Init(transform);
        

        targetPosition = new Vector2(0,0);
        targett = GameObject.Find("Targett").transform;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnDestroy(){
        Destroy(AIInstanceHandle);
    }

    private Vector2 GetVector2FromTransform(Transform t){
        return new Vector2(t.position.x,t.position.y);
    }

    private float GetClampedDistance(Vector2 p1,Vector2 p2,float min){
        return Mathf.Max((p1-p2).magnitude,min);
    }

    Vector2 MoveToPoint(Vector2 target){
        return (target - GetVector2FromTransform(transform)).normalized;
    }

     Vector2 MoveAwayFromPoint(Vector2 target){
        return -MoveToPoint(target);
    }

    Vector2 WallRayTest(Vector2 direction,float minDistance){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        Vector2 ret = new Vector2(0,0);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject != gameObject){
                float distance = (new Vector2(hit.point.x,hit.point.y) - GetVector2FromTransform(transform)).magnitude;
                if(distance < minDistance){
                    Vector3 v = Vector3.Cross(new Vector3(-direction.x,0,-direction.y),Vector3.up);

                    ret = new Vector2(v.x,v.z);
                }
            }
        }
        return ret;
    }

    Vector2 GetMoveDirection(Vector2 target){
        Vector2 sumVec = new Vector2(0,0);
        Vector2 myPos = GetVector2FromTransform(transform);
        foreach(Transform bot in AIHandleObject.transform){
            Ai_Bot_Handle ai_bot = bot.gameObject.GetComponent<Ai_Bot_Handle>();
            if(ai_bot.GetTransform() == transform)continue;
            Vector2 botPos = GetVector2FromTransform(ai_bot.GetTransform());
            float avoid_factor = (0.71415f/GetClampedDistance(botPos,myPos,0.1f));
            sumVec += MoveAwayFromPoint(botPos) *avoid_factor*avoid_factor;
        
        }
        sumVec += MoveToPoint(target)*1.3f;

        float minDistance = 1;
        sumVec += WallRayTest(Vector2.up,minDistance)*3.5f;
        sumVec += WallRayTest(Vector2.right,minDistance)*3.5f;
        sumVec += WallRayTest(-Vector2.up,minDistance)*3.5f;
        sumVec += WallRayTest(-Vector2.right,minDistance)*3.5f;

        return sumVec;
    }
    private Vector2 translation = new Vector2(0,0);
    // Update is called once per frame
    void Update()
    {
        if(targett != null)
        targetPosition = new Vector2(targett.position.x,targett.position.y);
    }

    void FixedUpdate(){
        

        translation = GetMoveDirection(targetPosition) * Speed * (1.0f/60.0f);
        Vector2 newPos = rigidbody.position + translation;
    
        rigidbody.MovePosition(newPos);
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position,transform.position + new Vector3(translation.x * 10,translation.y*10,0));
    }
}
