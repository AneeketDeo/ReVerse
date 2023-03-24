using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    //public Transform 
    public Rigidbody2D rb;
    public float fireSpeed = 200f;
    
    //enemy manager
    [SerializeField] private BossController boss;
    [SerializeField] private Enemy_SlenderOrc enemy_Slender;
    [SerializeField] private Enemy_SlenderOrc enemy_Knife;
    
    [SerializeField] private PlayerController controller;
    
    void Start()
    {
        rb.velocity = transform.right * fireSpeed ;
    }
    
    void OnTriggerEnter2D(Collider2D collider){
    	if(collider.gameObject.tag == "Enemy"){
    		boss.TakeDamage(1);
    		Destroy(gameObject);
    	}
    	
    	if(collider.gameObject.tag == "Slender"){
    		enemy_Slender.TakeDamage(1);
    		Destroy(gameObject);
    	}
    	
    	if(collider.gameObject.tag == "Knife"){
    		enemy_Knife.TakeDamage(1);
    		Destroy(gameObject);
    	}
    	
    	if(collider.gameObject.tag == "Player"){
    		controller.projectileCollected();
    		
    		//play sound
     		FindObjectOfType<AudioManager>().Play("Acquire");
     		
    		Destroy(gameObject);
    	}
    	
    }

   
}
