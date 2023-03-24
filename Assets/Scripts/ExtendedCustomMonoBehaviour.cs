using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedCustomMonoBehaviour : MonoBehaviour
{
    //This class is used to add some common variable to Mobehaviour rather than constantly repeating 
    //same declarations in every class

    public Transform myTransform;
    public GameObject myGO;
    public Rigidbody2D myBody;

    public bool didInit;
    public bool canControl;
    public static bool reverseMode = false;
    public static bool isGrounded;

    public enum PlayerState
    {
        walking,
        jumping,
        falling,
        landing
    };

    public static PlayerState currentState;

    public int id;

    [System.NonSerialized]
    public Vector3 tempVEC;

    [System.NonSerialized]
    public Transform tempTR;

    public virtual void SetID(int anID){
        id = anID;
    }

    public void ChangeState(PlayerState state){
        currentState = state;
    }

    public PlayerState GetState(){
        return currentState;
    }
}
