using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameController gameController;
    
    void OnTriggerEnter2D(Collider2D collider){
    	if(collider.gameObject.tag == "Player"){
    		Debug.Log("Game Over");
    		gameController.LevelEnded();
    	}
    }
}
