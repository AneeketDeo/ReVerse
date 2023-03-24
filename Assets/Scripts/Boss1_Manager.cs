using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Manager : MonoBehaviour
{
 	 //Attack Rate
    float attackRate = 0.5f, nextAttackTime = 0f;
    private float waitForSeconds = 2.0f;
    private bool summoned = false;
    private bool tired = false;
    
    public Animator animator;
    public GameController gameController;
    private BossController boss;
    private Boss1PHASE phase;
    
    void Start(){
    	//Monologue here
        boss = gameObject.GetComponent<BossController>();
        phase = gameObject.GetComponent<Boss1PHASE>();
    }
    
    void Update(){
    //------------>PHASE 1<--------------//
        //ATTACK
        if(boss.currentHealth > 25){
        	//StartCoroutine(Delay(5));
        	if(Time.time >= nextAttackTime){
		    animator.SetTrigger("isAttack");
		    nextAttackTime = Time.time + 1f / attackRate;
        	}
        }
        //SUMMON
        else if (boss.currentHealth <= 25 && boss.currentHealth > 20){
        	
        	animator.ResetTrigger("isAttack");
        	
        	StartCoroutine("BossSummon");
		
	//ATTACK
		if(summoned){
			if(Time.time >= nextAttackTime){
			    animator.SetTrigger("isAttack");
			    nextAttackTime = Time.time + 1f / attackRate;
        		}
		}
		

	}
	
        //------------>PHASE 2<--------------//
        //ATTACK 2 (UP)
	else if(boss.currentHealth <= 20 && boss.currentHealth > 10){
		animator.ResetTrigger("Summon");
		animator.ResetTrigger("isAttack");
		if(Time.time >= nextAttackTime){
		    animator.SetTrigger("Attack2");
		    nextAttackTime = Time.time + 1f / attackRate;
        	}
        	
        	StartCoroutine("BossTired");
        	
        	if(tired){
			if(Time.time >= nextAttackTime){
			    animator.SetTrigger("Attack2");
			    nextAttackTime = Time.time + 1f / attackRate;
        		}
		}
		
	}
	else if(boss.currentHealth < 10){
		Time.timeScale = 0.5f;
		animator.SetTrigger("isDead");
		GetComponent<Collider2D>().enabled = false;
		Invoke("BossDied", 2.0f);
	}
	//TIRED
	/*else if(boss.currentHealth <= 17 && boss.currentHealth > 14){
		animator.ResetTrigger("Attack2");
        	
        	//StartCoroutine("BossSummon");
        	animator.SetTrigger("Tired");
	}
	//ATTACK 2 (UP)
	else if(boss.currentHealth <= 14 && boss.currentHealth > 10){
		animator.ResetTrigger("Summon");
		animator.ResetTrigger("isAttack");
		if(summoned){
			if(Time.time >= nextAttackTime){
			    animator.SetTrigger("Attack2");
			    nextAttackTime = Time.time + 1f / attackRate;
        		}
		}
		
	}
		
		
		
        	
        	      	

        

        if(boss.currentHealth <= 20 && boss.currentHealth > 15){
        	animator.SetTrigger("appear");
        	
        }
        //SUMMON
        else if (boss.currentHealth <= 15 ){
        	animator.ResetTrigger("upAttack");
        	
        	if(boss.currentHealth > 14){
        		//summon anim
        		animator.SetTrigger("Summon");
        	}
        	animator.SetTrigger("disappear");
        }

        //set trigger for attack*/

    }
    
    IEnumerator BossSummon(){
    	//summon anim
	animator.SetTrigger("Summon");
	summoned = true;
   	yield return new WaitForSeconds(500);
   }
   
   IEnumerator BossTired(){
    	//tired anim
	animator.SetTrigger("Tired");
	tired = true;
   	yield return new WaitForSeconds(1);
   }
   
   void BossDied(){
	gameController.LevelEnded();
   }
}
