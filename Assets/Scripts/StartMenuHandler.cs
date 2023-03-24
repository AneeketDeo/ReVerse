using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{
    private List<string> sceneHistory = new List<string>(); 
    
    void Start(){
    	DontDestroyOnLoad(this.gameObject);
    }
    
    //-------------------->START MENU<--------------------------//
    public void StartButton_Clicked(){
    	SceneManager.LoadScene("DimensionMenu");
    }
    
    public void SettingsButton_Clicked(){
	//Load Settings Menu
	Debug.Log("Settings button clicked");
    }
    
    public void ExitButton_Clicked(){
	Application.Quit();
	Debug.Log("Exited");
    }
    
    //-------------------->DIMENSION MENU<--------------------------//
    public void dimensionOne_Clicked(){
    	SceneManager.LoadScene("DimensionOne");
    }
    
    public void dimensionTwo_Clicked(){
    	SceneManager.LoadScene("DimensionTwo");
    }
    
    public void dimensionThree_Clicked(){
    	SceneManager.LoadScene("DimensionThree");
    }
    
    public void dimensionFour_Clicked(){
    	SceneManager.LoadScene("DimensionFour");
    }
    
    public void BackButton_Clicked(){
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    //1. DIMENSION ONE
    //level loader
    public void Level1_1(){
    	SceneManager.LoadScene("Level 1-1");
    }
    public void Level1_2(){
    	SceneManager.LoadScene("Level 1-2");
    }
    public void Level1_3(){
    	SceneManager.LoadScene("Level 1-3");
    }
    public void Level1_4(){
    	SceneManager.LoadScene("Level 1-4");
    }
    public void Level1_5(){
    	SceneManager.LoadScene("Level 1-5");
    }
    public void Level1_6(){
    	SceneManager.LoadScene("Level 1-6");
    }
    public void Level1_7(){
    	SceneManager.LoadScene("Level 1-7");
    }
    public void Level1_8(){
    	SceneManager.LoadScene("Level 1-8");
    }
    public void Level1_9(){
    	SceneManager.LoadScene("Level 1-9");
    }    
    
    //-------------------->GAME OVER<--------------------------//
    public void NextLevel(){
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  	
    }
    
    public void RestartLevel(){
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
