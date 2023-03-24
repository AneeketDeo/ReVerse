using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    //HEALTH
     public float maxHealth = 30, currentHealth;
     
     private Animator animator;
     
    void Start()
    {
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        
    }
    
    public void TakeDamage(int damage){
    	currentHealth -= damage;
    	animator.SetTrigger("gotHit");
    	
    	if(currentHealth <= 0){
    		Die();
    	}
    }
    
    public void Die(){
    	//slowdown time
    	
    	//animation
    	animator.SetBool("isDead", true);
    	
    	//disable collider
    	gameObject.GetComponent<Collider2D>().enabled = false;
    	
    	//disable animator
    	gameObject.GetComponent<Animator>().enabled = false;
    	
    	//disable this script
    	this.enabled = false;
    }
}
