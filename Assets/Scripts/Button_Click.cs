using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Click : ExtendedCustomMonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;



    // public Button btn_Jump, btn_Attack;
    public Button btn;
    public float jumpForce = 1f;
    public Vector3 jump = new Vector3(0, 2.0f, 0);
    // private PlayerState currentState;

    public Vector2 horizontal_input;
    public float moveSpeed = 6f;
    

    void Start(){
        rb = myBody; 

    }

    void Update(){
        

    }

    public void button_jump_Clicked(){
        currentState = GetState();
        
        // if(currentState == PlayerState.walking){
        if(isGrounded){
            // ChangeState(PlayerState.jumping);
            myBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            //jumping animation
            // animator.SetBool("isJumped", true);
            
        }  
    }

    public void button_Attack_Clicked(){
        currentState = GetState();
        Debug.Log("Attack");
        Debug.Log("current state="+ currentState);
        
    }

    public void button_Right_Clicked(){
        Debug.Log("moved right");
        horizontal_input = new Vector2(-1,0);
        // myTransform.Translate(horizontal_input * moveSpeed * Time.deltaTime);
        // myTransform.position += myTransform.right * moveSpeed * Time.deltaTime;
        // rb.AddForce(myTransform.right * moveSpeed * Time.deltaTime);
        rb.velocity = (- myTransform.right) * moveSpeed * Time.deltaTime;
    }

    public void button_Left_Clicked(){
        Debug.Log("moved left");
        horizontal_input = new Vector2(1,0);
        // myTransform.Translate(horizontal_input * moveSpeed * Time.deltaTime);
        // myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        // rb.AddForce((-myTransform.right) * moveSpeed * Time.deltaTime);
        rb.velocity = myTransform.right * moveSpeed * Time.deltaTime;
    }



   
}
