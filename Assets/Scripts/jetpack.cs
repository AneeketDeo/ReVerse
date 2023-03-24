using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpack : GameController
{
    void OnTriggerEnter2D(Collider2D collider){
    	GameMode_Glide();
    }
}
