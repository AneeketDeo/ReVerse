using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] private GameObject camera;
    private Transform myTransform;
    [SerializeField] private float parallaxEffect; 
    void Start()
    {
        myTransform = transform;
        startPos = myTransform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void FixedUpdate()
    {
        float repeatBackground = (camera.transform.position.x * (1 - parallaxEffect));
        float dist = camera.transform.position.x * parallaxEffect;

        //parallax
        myTransform.position = new Vector3(startPos + dist, myTransform.position.y, myTransform.position.y);

        //infinite scrolling
        if(repeatBackground > startPos + length)
            startPos += length;

        else if(repeatBackground < startPos - length)
            startPos -= length;
        
    }
}
