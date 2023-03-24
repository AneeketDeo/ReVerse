using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : ExtendedCustomMonoBehaviour
{
    private Quaternion targetRotation;
    public Animator animator;
    private float thePos;
    private float moveXAmount;
    private float moveYAmount;//required to show tilting of the player in 3d axis
    public float moveXSpeed = 40f;
    public float jumpForce = 2f;
    //public Vector3 jump = new Vector3(0, 2.0f, 0);

    //Better Jump 1
    //public float fallMultiplier = 2.5f;
    //public float lowJumpMultiplier = 2f;
    
    //Better jump 2
    public float gravity, jumpVelocity, groundHeight;
    public Vector2 velocity;
    private bool buttonClicked = false;
    
    //------------------->Distance<-----------------------//
    public float distance = 0;
    public float halfDistance = 0;
    public Transform startPoint ;
    public Transform followPlayer ;
    public Transform endPoint;
    
    //--------------------->DASH<------------------------//
    public float dashSpeed = 30f;
    public float dashWaitTime = 0.5f;
    public Vector3 dashMovement;


    [System.NonSerialized]
    public float horizontal_input;
    // public float vertical_input;  


    public virtual void GetInput(){
        horizontal_input = 1;
        // vertical_input = default_input.GetVertical();
        // ifJumped = jumpButton.Get_Jump();
    }
    
    //public void Start(){
    	//Sound
        //FindObjectOfType<AudioManager>().Play("Footsteps");

    //}
    
    public void Update(){

        // BetterJump();
      
    }

    void FixedUpdate()
    {
         Update_Movement();
         if(buttonClicked){
            buttonClicked = false;            
            myBody.gravityScale = gravity;
        }

        //distance += velocity.x * Time.fixedDeltaTime;
        distance = Vector2.Distance(startPoint.position, followPlayer.position);

    }

    public virtual void Update_Movement(){
        GetInput();
        //------------------->OLD RUNNING CODE<---------------------//
        // Vector3 movement = new Vector3(horizontal_input * moveXSpeed, 0, 0);
        // movement *= Time.deltaTime;
	// myTransform.Translate(movement);
	
	
        //------------------->VELOCITY CODE<--------------------//
        velocity = myBody.velocity;
        velocity.x = moveXSpeed *Time.deltaTime;
        myBody.velocity = velocity;
        
        

        
        ChangeState(PlayerState.walking);
        //running animation
        // animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // animator.SetBool("isJump", false);
        
        //-----------> DASH <-----------//
        dashMovement = new Vector3(horizontal_input * dashSpeed, 0, 0);
        dashMovement *= Time.deltaTime;

    }

    //button clicks
    public void button_jump_Clicked(){
        currentState = GetState();
        buttonClicked = true;

        // Vector2 pos = myTransform.position;

    
        // if(currentState == PlayerState.walking){
        if(isGrounded){
            ChangeState(PlayerState.jumping);
            // myBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            
            ChangeState(PlayerState.falling);
            animator.SetTrigger("Fall");

            //--------------->BETTER JUMP<----------------------//
            // isGrounded = false;
            // velocity.y = jumpVelocity;

            // Debug.Log("need to jump!");

            // pos.y += velocity.y * Time.deltaTime;
            // velocity.y += gravity * Time.deltaTime;

            // myTransform.position = pos;
            // if(pos.y <= groundHeight){
            //     pos.y = groundHeight; 
            // }

            //jumping animation
            // animator.SetBool("isJumped", true);
            animator.SetBool("isJump",true);
        }  
    }
    
    public void button_dash_Clicked(){
    	Debug.Log("Dash clicked");
    	StartCoroutine("Dash");
    	//animator.SetBool("isDash", false);
    	
    }
    
    IEnumerator Dash(){
    	animator.SetTrigger("isDash");
    	//float currentSpeed = moveXSpeed; 
    	//yield return new WaitForSeconds(dashWaitTime);
    	//moveXSpeed += dashSpeed;
    	myTransform.Translate(dashMovement);
    	yield return null;    	
    }

    

    // void BetterJump(){
    //     if(myBody.velocity.y < 0){
    //         myBody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    //     }
    //     else if(myBody.velocity.y > 0 && isGrounded){
    //         myBody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    //     }
    // }

}
