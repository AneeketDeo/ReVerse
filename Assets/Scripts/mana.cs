using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana : MonoBehaviour
{
    [SerializeField] 
    private PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collider){
    	//collect the coin
     	controller.manaCollected();
     	
     	//play sound
     	FindObjectOfType<AudioManager>().Play("Acquire");
    	
    	//disable the coin
    	gameObject.SetActive(false);
    	
    }
}
