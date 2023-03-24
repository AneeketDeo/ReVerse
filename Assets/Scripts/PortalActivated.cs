using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivated : ExtendedCustomMonoBehaviour
{
   /* //gamecontroller
    [SerializeField]
    private GameObject gameObject;

    //Buttons
    [SerializeField]
    private GameObject rightbtn, leftbtn;

    [SerializeField]
    private Transform jumpbtn;

    //Basemovement script 
    private BaseMovement baseMovement;

    //ReverseMovement script
    private ReverseMovement reverseMovement;

    [System.NonSerialized]
    public GameController controller;

    public Vector2 jumpPos = new Vector2(230, -119);
    public float jumpPosX = 424f;
    public float XPos;

    void Start() {
        controller = gameObject.GetComponent<GameController>();

        baseMovement = myGO.GetComponent<BaseMovement>();
        reverseMovement = myGO.GetComponent<ReverseMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collider) {
        
        switch(collider.gameObject.tag){
            case "Player":
                // animator.SetBool("isJumped", false);
                //--> ACTIVATE THE PORTAL <--//
                controller.FrontLevelEnded();
                break;

            default:
                // Debug.Log("is grounded didnt work");
                break;
       }

    }

    public void ReverseMode(){
        myTransform.Rotate(0,180,0);

        //delay for player to move past the portal
        //disable basemovement script to enable reversemode movement script
        Invoke("disableBaseMovement", 4);

        //control switching
        XPos = jumpbtn.position.x;
        XPos += jumpPosX;
        jumpPos = new Vector2(XPos, jumpbtn.position.y);
        jumpbtn.position = jumpPos;
        rightbtn.SetActive(true);
        leftbtn.SetActive(true);

        //enable the reverse movement script 
        reverseMovement.enabled = true;
        reverseMode = true;


    }

    private void disableBaseMovement(){
        baseMovement.enabled = false;

    }*/

    
}
