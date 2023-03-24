using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideMovement : ExtendedCustomMonoBehaviour
{
    public GameObject player;
    public GameObject jetPlayer;
    
    
    public Vector3 playerSize;
    public float boostForce = 5f;
    
    //velocity 
    public float velocityX, velocityY;
    
    //gravity
    public float gravity = 3f;
    
    
    void Start()
    {
        //disable base movement
        player.SetActive(false);
        jetPlayer.SetActive(true);
        myTransform.localScale = playerSize;
    }

    void FixedUpdate()
    {
    	//set velocity along 4th quadrant
    	//horizontal speed like base movement
    	myBody.velocity = new Vector2(velocityX * Time.deltaTime, velocityY);
    	
    	//add gravity
    	myBody.gravityScale = gravity;
    	
    	//add force if jumped -> along 1st quadrant
        
    }
    
    public void button_jump_clicked(){
    	Debug.Log("Jump clicked 1");
    	myBody.velocity = new Vector2(myBody.velocity.x, boostForce);
    }
}
