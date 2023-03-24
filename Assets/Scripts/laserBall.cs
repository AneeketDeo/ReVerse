using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBall : Boss1PHASE
{
    public Transform hitTarget;
    public Rigidbody2D rb;
    public float fireSpeed = 20f;
    
    //---------->Player script<------------//
    [SerializeField] private PlayerController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        if(bossPhase == BossPhase.phase1){
        	rb.velocity = new Vector3(-15, -9, 0) * fireSpeed ;
        }
        
        if(bossPhase == BossPhase.phase2){
        	rb.velocity = new Vector3(-10, 9, 0) * fireSpeed * 5f; ;
        }

    }

    // Update is called once per frame
    void Update()
    {
    	
       
    }
    
    void OnTriggerEnter2D(Collider2D collider){
    	
    	if(collider.gameObject.tag == "Player"){
    		controller.TakeDamage(1);
    		Destroy(gameObject);
    	}
    	else if(collider.gameObject.tag == "Platform" ){
    		Destroy(gameObject);
    	}
    }
}
