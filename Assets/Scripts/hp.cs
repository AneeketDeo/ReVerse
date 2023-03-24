using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    [SerializeField] 
    private PlayerController controller;


    private void OnTriggerEnter2D(Collider2D collider){
    	//collect the hp
     	controller.hpCollected();
    	
    	//play sound
     	FindObjectOfType<AudioManager>().Play("Acquire");
     	
    	//disable the coin
    	gameObject.SetActive(false);
    	
    }
}
