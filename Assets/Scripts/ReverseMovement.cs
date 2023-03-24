using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D controller2D;

    public bool ifJumped = false;
    public bool ifCrouched = false;
    public float moveXSpeed = 40f;
    
    [System.NonSerialized]
    public float horizontal_input;

       
    void Update()
    {
        
    }

    public void button_jump_Clicked(){
        //setting for character controller 2d
        ifJumped = true;
        // if(currentState == PlayerState.walking){
 
    }

    public void button_Attack_Clicked(){
        Debug.Log("Attack");
        
    }

    public void button_Right_Clicked(){
        Debug.Log("moved right");
        horizontal_input = -1 * moveXSpeed;

    }

    public void button_Left_Clicked(){
        Debug.Log("moved left");
        horizontal_input = 1 * moveXSpeed;
    }

    void FixedUpdate() {
        // if(reverseMode){
            Debug.Log(ifJumped);
            controller2D.Move(horizontal_input * Time.fixedDeltaTime, ifCrouched, ifJumped);
        // }
    }
}
