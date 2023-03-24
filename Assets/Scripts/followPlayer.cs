using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 targetOffset;
    public float moveSpeed = 2f;
    private Transform myTransform;

    void Start(){
        myTransform = transform;
    }

    public void SetTarget(Transform aTransform){
        followTarget = aTransform;
    }

    void LateUpdate()
    {
        if(followTarget != null){
            myTransform.position = Vector3.Lerp(
                followTarget.position + targetOffset,
                myTransform.position,  
                moveSpeed * Time.deltaTime
            );
        }
    }
}
