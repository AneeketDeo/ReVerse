using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vase : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particle;
    
    [SerializeField] private Transform Mana;
    [SerializeField] private Transform Health;   
    [SerializeField] private Transform Projectile;
    
    public void Start(){
    	animator = GetComponent<Animator>();
    }
    	
    public void vaseDestroyed(){
    	//animation or Instantiate
    	animator.SetBool("vaseDestroyed", true);
    	Instantiate(particle, transform.position, transform.rotation);
    	particle.Play();
    	
    	//sound
    	FindObjectOfType<AudioManager>().Play("vase breaking");
    	
    	//disable vase
    	GetComponent<Collider2D>().enabled = false;
    	
    	//spawn coins or mana
	spawnSomething();
    }
    
    public void spawnSomething(){
        	    
    	float spawnChance = Random.Range(0, 100);
    	
    	if(spawnChance >= 60 ){
	    	//spawn Mana		//->40 % chance to spawn Mana
	    	Instantiate(Mana, transform.position + new Vector3(0, 5, 0), transform.rotation);
	}
    	else if(spawnChance < 20){
    		//spawn Health		//->20% chance to spawn Health
    		Instantiate(Health, transform.position + new Vector3(0, 5, 0), transform.rotation);
    	}
    	else if(spawnChance < 60 && spawnChance >= 20){
    		//spawn projectile	//->40 % chance to spawn Projectiles
	    	Instantiate(Projectile, transform.position + new Vector3(0, 5, 0), transform.rotation);
    	}
    	
    	
    	
    }
}
