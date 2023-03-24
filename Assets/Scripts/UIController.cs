using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //------->HEALTH BAR<----------//
    public Slider healthSlider;
    public Gradient healthGradient;
    public Image healthFill;
    
    //------->MANA BAR<----------//
    public Slider manaSlider;
    public Gradient manaGradient;
    public Image manaFill;

    //--------->SCORE<-------------//
    [SerializeField] private Text scoreText;
    // [SerializeField] private BaseMovement movement;
    
    //--------->COINS<-------------//    
    [SerializeField] private Text coinsText;
    
    //--------->PROJECTILE<-------------//    
    [SerializeField] private Text projectileText;
    
    //***************************************************************************************//
    
    //---------------->HEALTH<---------------------//
    public void SetMaxHealth(int health){
        healthSlider.maxValue = health;
        healthSlider.value = health;
        healthFill.color = healthGradient.Evaluate(1f);

    }

    public void SetHealth(int health){
        healthSlider.value = health;
        healthFill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
    
     //---------------->MANA<---------------------//
    public void SetMaxMana(int mana){
        manaSlider.maxValue = mana;
        manaSlider.value = mana;
        manaFill.color = manaGradient.Evaluate(1f);

    }

    public void SetMana(int mana){
        manaSlider.value = mana;
        manaFill.color = manaGradient.Evaluate(manaSlider.normalizedValue);
    }

    //---------------->SCORE<---------------------//
    public void SetScore(int score){
        scoreText.text = score.ToString() + " m";
    }
    
    public string GetScore(){
    	return scoreText.text;
    }
    
    //---------------->COINS<---------------------//
    public void SetCoins(int numCoins){
    	coinsText.text = " " + numCoins.ToString();
    }
    
    public string GetCoins(){
    	return coinsText.text;
    }
    
    //---------------->PROJECTILE<---------------------//
    public void SetProjectiles(int numProjectile){
    	projectileText.text = " " + numProjectile.ToString();
    }
    
    public string GetProjectiles(){
    	return projectileText.text;
    }
}
