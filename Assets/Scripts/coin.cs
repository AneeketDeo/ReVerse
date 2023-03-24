using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    //private GameObject Player;
    [SerializeField] 
    private PlayerController controller;
    
    void Start(){
    	//Player = GameObject.AddComponent<NewSprite>();
    	//controller = Player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
    	//collect the coin
     	controller.coinCollected();
     	
     	//play sound
     	FindObjectOfType<AudioManager>().Play("coin");
     	
    	//disable the coin
    	gameObject.SetActive(false);
    	
    }
    
}
