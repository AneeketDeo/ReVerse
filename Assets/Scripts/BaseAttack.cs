using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    //Animation
    public Animator animator;

    //Enemy Detection
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
  
    
    //Vase Detection
    public LayerMask vaseLayer;
    
    //Stalac Detection
    public LayerMask stalacLayer;

    //Attack Rate
    public float attackRate = 2f, nextAttackTime = 0f;


    //Attack
    public int baseHitDamage = 1;
    
    //--------------------------->FIRE BALL<---------------------------//
    public GameObject fireBall;
    public Transform firePoint;
    public float fireSpeed = 20f;
    

    public void button_Attack_Clicked(){

        if(Time.time >= nextAttackTime){
            SwordAttack();
            nextAttackTime = Time.time + 1f / attackRate;

        }
            //animator.SetBool("isAttack", false); 
    }

    void SwordAttack(){
	
        //animation
        animator.SetTrigger("isAttack");
        
        //sound
        FindObjectOfType<AudioManager>().Play("whoosh");


        //range of weapon
        //1. Enemies
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //2. Vase's
        Collider2D[] vaseHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, vaseLayer);
        
        //3. Stalac's
        Collider2D[] stalacHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, stalacLayer);
        
        //damage enemies
        foreach(Collider2D enemy in enemiesHit){
            enemy.GetComponent<Collider2D>().isTrigger = false;
            enemy.GetComponent<Enemy_SlenderOrc>().TakeDamage(baseHitDamage);        
            
        }
        
        //attacking Vase's
        foreach(Collider2D vase in vaseHit){
        	vase.GetComponent<vase>().vaseDestroyed();
        }
        
        //attacking stalac
        foreach(Collider2D stalac in stalacHit){
        	Debug.Log("hit stalac");
        	stalac.GetComponent<Stalactite>().stalacDestroyed();
        }
        
        
    }
    
    public void FireBallAttack(){
    	//animation maybe?
    	animator.SetTrigger("rangeAttack");
    	
    	//spawn fireball
    	Instantiate(fireBall, firePoint.position, firePoint.rotation);
    	
    	
    	//damage enemies
    } 

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
