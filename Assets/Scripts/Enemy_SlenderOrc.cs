using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SlenderOrc : MonoBehaviour
{
    //--------------->Enemy stats<------------------//
    public float currentHealth, maxHealth = 2f;
    
    //Animation
    public Animator animator;

    //Enemy Detection
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    
    //Player Detection
    public Transform toAttackCentre;
    public float toAttackRange = 0.5f;
    
    //Did player attacked
    public bool didAttack = false;

    //Attack Rate
    float attackRate = 2f, nextAttackTime = 0f;
    private bool prevCalled = false;

    //Attack
    public int baseHitDamage = 1;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] isPlayer = Physics2D.OverlapCircleAll(toAttackCentre.position, toAttackRange, playerLayer);
        
         foreach(Collider2D player in isPlayer){
         	
         	if(Time.time >= nextAttackTime){
			   SlenderAttack();
			  nextAttackTime = Time.time + 1f / attackRate;
      	      	}
         	                     
        }
    }
    
  //  public void OnCollisionEnter2D(Collider collider){
   // 	switch(collider.gameObject.tag):
    //		case "Player":
    //			Debug.log("collided with player");
   // }

    public void TakeDamage(int damage){
    	didAttack = true;
    	animator.SetTrigger("enemyGotHit");
        currentHealth -= damage;
        
        if(currentHealth <= 0){
		Die();
        }
        
    }
    
    void SlenderAttack(){
    
    	if(prevCalled || didAttack){
    		return;
    	}
	
	prevCalled = true;
        //animation
	animator.SetTrigger("Enemy_Attack");

        //range of weapon
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);


        //damage Player
        
        foreach(Collider2D player in playerHit){
            Debug.Log("hit an player");
            player.GetComponent<PlayerController>().TakeDamage(baseHitDamage);
            GetComponent<Collider2D>().isTrigger = true;
        }
      
    }
    
    public void Die(){
   	//animation
   	animator.SetBool("enemyDied", true);
   	
   	Debug.Log("enemy Died");
   	
   	//disable the enemy
   	GetComponent<Collider2D>().enabled = false;
   	this.enabled = false;
   	

   }
    
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(toAttackCentre.position, toAttackRange);
    }
}
