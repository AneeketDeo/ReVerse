using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameController : MonoBehaviour
{    

    //------------------->GAMEOBJECTS & SCRIPTS<------------------------//
    [SerializeField] private StartMenuHandler sceneHandler;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject audio;
    [SerializeField] private GameObject camera;
    [SerializeField] private UIController uIController;
    
    //-------------------->GAME MODES<---------------------------------//
    //1.Glide
    [SerializeField] private GameObject jetPlayer;
    [SerializeField] private GlideMovement glide;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private CinemachineVirtualCamera jetCamera;
    
    
    //------------------->GAME OVER SCREEN<------------------------//
    //1. Lose
    [SerializeField] private GameObject GameOver_Lose;
    [SerializeField] private Text gameLost_Coins;
    [SerializeField] private Text gameLost_Projectiles;
    [SerializeField] private Text gameLost_Score;
    
    //2. Win
    [SerializeField] private GameObject GameOver_Win;
    [SerializeField] private Text gameOver_Coins;
    [SerializeField] private Text gameOver_Projectiles;
    [SerializeField] private Text gameOver_Score;
    
    //------------------->PAUSE MENU<------------------------//
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject playingArea;
    
    void Start(){
    	DontDestroyOnLoad(this.gameObject);
    }
    
    void Update(){
    	if(Input.GetKeyDown(KeyCode.A)){
    		glide.enabled = true;
    	}	
    }
    
    public void LevelPaused(){
    	//stop time actually pause it!
    	Time.timeScale = 0;
    	
    	//display pause screen
    	pauseMenu.SetActive(true);
    	
    	//disable playing area
    	playingArea.SetActive(false);
    	
    	//disable audio listener
	camera.GetComponent<AudioListener>().enabled = false;
    	
    }
    
    public void LevelResumed(){
    	//resume time 
    	Time.timeScale = 1;
    	
    	//hide pause screen
    	pauseMenu.SetActive(false);
    	
    	//enable playing area
    	playingArea.SetActive(true);
    	
    	//disable audio listener
	camera.GetComponent<AudioListener>().enabled = true;
    	
    }
    
    public void LevelLost(){
    	//Gameover screen
	GameOver_Lose.SetActive(true);
	
	//disable player
	player.SetActive(false);
    	
    	//disable audio
    	//audio.SetActive(false);
    	
    	//coins collected
    	gameLost_Coins.text = uIController.GetCoins();
    	
    	//projectiles collected
    	gameLost_Projectiles.text = uIController.GetProjectiles();
    	
    	//score
    	gameLost_Score.text = uIController.GetScore();
    }


    public void LevelEnded(){
    	//Gameover screen
	GameOver_Win.SetActive(true);
	
	//disable player
	player.SetActive(false);
    	
    	//disable audio
    	audio.SetActive(false);
    	
    	//coins collected
    	gameOver_Coins.text = uIController.GetCoins();
    	
    	//projectiles collected
    	gameOver_Projectiles.text = uIController.GetProjectiles();
    	
    	//score
    	gameOver_Score.text = uIController.GetScore();
    }
    
    public void GameMode_Glide(){
    	//switch player
    	player.SetActive(false);
    	jetPlayer.SetActive(true);
    	
    	//switch camera'
    	jetCamera.Priority = 1;
    	mainCamera.Priority = 0;
    	
    }
    
}
