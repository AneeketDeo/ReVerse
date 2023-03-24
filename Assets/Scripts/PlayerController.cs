using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ExtendedCustomMonoBehaviour
{
    public GameController gameController;
    public Animator animator;
    // public GameObject PlayerScore;
    [SerializeField] private UIController healthBar;
    [SerializeField] private UIController manaBar;
    [SerializeField] private UIController scoreTxt;
    [SerializeField] private UIController coinsTxt;
    [SerializeField] private UIController projectileTxt;

    [SerializeField] private BaseMovement movement;
    
    //------------------>Spikes<----------------------------//
    Collider2D[] spikes;

    //------------------->Player Stats<--------------------//
    private int maxHealth = 3, currentHealth;
    private int maxMana = 10, mana;
    private int Score = 0;
    private int coins = 0;
    private int projectiles = 0;



   void OnCollisionEnter2D(Collision2D collider){
       switch(collider.gameObject.tag){
            case "Platform":
                // Debug.Log("collided with platform");
                // animator.SetBool("isJumped", false);
                ChangeState(PlayerState.walking); 
                isGrounded = true;
                animator.SetBool("isJump", false);
                animator.ResetTrigger("Fall");
                break;
            
            case "Enemy":
                // Debug.Log("touched enemy and player lost a life");
                // myDataManager.ReduceHealth(1);
                // Debug.Log("health="+myDataManager.GetHealth());
                break;
                
             case "Yikes":
                TakeDamage(1);
		GetComponent<Collider2D>().enabled = false;
		 Invoke("ColliderSwitch", 3f);
                break;
                
              
             	

            default:
                // Debug.Log("is grounded didnt work");
                break;
       }
   }

   void OnCollisionExit2D(Collision2D collider){
        switch(collider.gameObject.tag){
            case "Platform":
                ChangeState(PlayerState.jumping);
                isGrounded = false;
                break;

            default:
                // Debug.Log("trigger exit entered and didnt work");
                break;
        }
    }

    public void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
        mana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(1);
        }
        ScoredDistance();
    }

    public void TakeDamage(int damage){
    	animator.SetTrigger("gotHit");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        //sound
        FindObjectOfType<AudioManager>().Play("grunt");
        
        if(currentHealth <= 0){
		Die();
        }
    }

//    private void OnTriggerEnter(Collider other) {
//        //react to triggers here
//    }

//    public void PlayerFinished(){
//        //deal with the end of the game for this player
//    }

   public void ScoredDistance(){
       Score = Mathf.FloorToInt(movement.distance);
       scoreTxt.SetScore(Score);
   }
   
   public void coinCollected(){
   	coins += 1;
   	coinsTxt.SetCoins(coins);
   }
   
   public void hpCollected(){
   	currentHealth += 1;
   	if(currentHealth > maxHealth){
   		return;
   	}
   	healthBar.SetHealth(currentHealth);
   }
   
    public void manaCollected(){
   	mana += 1;
     	Debug.Log("Mana="+ mana);
   	if(mana >= maxMana){
   		return;
   	}
   	manaBar.SetMana(mana);
   }
   
   public void projectileCollected(){
   	projectiles += 1;
   	projectileTxt.SetProjectiles(projectiles);
   }

   public void ColliderSwitch(){
   	
   	GetComponent<Collider2D>().enabled = true;
   
   }
   
   public void Die(){
   	//animation
   	animator.SetBool("isDie", true);
   	
   	//player stops
   	movement.enabled = false;
   	
   	StartCoroutine(Delay(2.0f));
   	gameController.LevelLost();
   	
   }
   
   IEnumerator Delay(float delay){
   	yield return new WaitForSeconds(delay);
   }






}
