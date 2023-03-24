using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 targetOffset;
    // public float moveSpeed = 2f;
    private Transform myTransform;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] [Range(0.01f, 1f)]
     private float smoothSpeed = 0.125f;

    void Start(){
        myTransform = transform;
    }

    public void SetTarget(Transform aTransform){
        followTarget = aTransform;
    }

    void LateUpdate()
    {
        if(followTarget != null){
            Vector3 desiredPosition = followTarget.position + targetOffset;
            myTransform.position = Vector3.SmoothDamp(myTransform.position, desiredPosition, ref velocity, smoothSpeed );
            
            //----------------------OLD CODE--------------------------//    
            // myTransform.position = Vector3.Lerp(
            //     followTarget.position + targetOffset,
            //     myTransform.position,  
            //     moveSpeed * Time.deltaTime
            // );
        }
    }
}
