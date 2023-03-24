using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particle;
    
    public Transform fallingPiece;
    
    void Start(){
    	animator = GetComponent<Animator>();
    	animator.SetTrigger("Fall");
    }
    
    void OnTriggerEnter2D(Collider2D collider){
    	if(collider.gameObject.tag == "Player"){
    		collider.GetComponent<PlayerController>().TakeDamage(1);
    	}
    }
    
    public void stalacDestroyed(){
    	animator.SetTrigger("Destroy");
    	FindObjectOfType<AudioManager>().Play("stone_breaking");
    	Instantiate(particle, fallingPiece.position, fallingPiece.rotation);
    	particle.Play();
    }
}
