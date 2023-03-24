using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1PHASE : MonoBehaviour
{
    //BOSS PHASE
    public enum BossPhase{
    	phase1, 
    	phase2,
    	phase3,
    	tired,
    	summon
    };
    
    public static BossPhase bossPhase;
    
    public static bool summoned = false;
    
    public Animator animator;
    public Transform laserBall;
    public Transform attackPoint;
    
    public Transform followPlayer;
    
    //summon points
    public Transform summonPoint1, summonPoint2;
    
    //Enemy array
    [SerializeField] private Transform[] enemyArray;
    
    //stalac
    [SerializeField] private Stalactite stalactite;
    public Transform stalac;
    public Transform stalacPoint;
    
    public void Boss1_Phase1(){
    	//phase
    	bossPhase = BossPhase.phase1;
    	
    	//spawn laser
    	Instantiate(laserBall, attackPoint.position, laserBall.rotation);
    }
    
    public void Boss1_Phase2(){
    	//phase
    	bossPhase = BossPhase.phase2;
    
    	//spawn laserBall
    	Instantiate(laserBall, attackPoint.position, laserBall.rotation);
    	
    	//spawn stalac
    	Instantiate(stalac, stalacPoint.position, stalacPoint.rotation);
    	
    	//break the stalac
    	//stalac.stalacFell();
    	
    }
    
    public void Boss1_Phase3(){
    	//phase
    	bossPhase = BossPhase.phase3;
    
    	//sine wave lasers
    }
    
    public void Boss1_Summon(){    	
    	
    	//phase
    	bossPhase = BossPhase.summon;
    	
    	//summon code
    	float summonChance = Random.Range(1, 10);
    	if(summonChance <= 5){
    		Instantiate(enemyArray[0], summonPoint1.position, enemyArray[0].rotation);
    		Instantiate(enemyArray[0], summonPoint1.position, enemyArray[0].rotation);
    		enemyArray[0].GetComponent<Animator>().SetLayerWeight(1,1);;
    		summoned = true;
    	}
    	else if(summonChance > 5){
    		Instantiate(enemyArray[1], summonPoint2.position, enemyArray[1].rotation);
    		Instantiate(enemyArray[1], summonPoint2.position, enemyArray[1].rotation);
    		enemyArray[1].GetComponent<Animator>().SetLayerWeight(1,1);
    		summoned = true;
    	}
    }
    
    public void Boss1_Disappear(){
    	ToggleBoss(animator, false, new Vector3(0, 180, 0), true, false);	//ToggleBoss(animator, cameraAnchor, rotation, basemovement, collider2D)
    	animator.SetBool("Summon", false);
    }
    
    public void Boss1_Appear(){
    	ToggleBoss(animator, true, new Vector3(0, 180, 0), false, true);//ToggleBoss(animator, cameraAnchor, rotation, basemovement, collider2D)
    }
    
    public void ToggleBoss(Animator animator, bool cameraAnchor, Vector3 rotation, bool baseMovement, bool collider2D){
    	animator.GetComponent<CameraAnchor>().enabled = cameraAnchor;
	animator.GetComponent<Transform>().Rotate(rotation);
	animator.GetComponent<BaseMovement>().enabled = baseMovement;
	animator.GetComponent<Collider2D>().enabled = collider2D;
    } 
}
