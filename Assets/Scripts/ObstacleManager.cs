using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{	
	public Animator animator;
	private void OnTriggerEnter2D(Collider2D collider) {
		animator.SetTrigger("gotHit");
	        
    }
}
