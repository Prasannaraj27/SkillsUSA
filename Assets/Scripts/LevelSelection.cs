using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("level"));
        //Debug.Log("Line 16:" + PlayerPrefs.GetInt("level"));
        int currentLevel  = PlayerPrefs.GetInt("level");
        Debug.Log("Line 17:" + currentLevel);
        if(currentLevel == 0) 
        {
            currentLevel = 2;
            PlayerPrefs.SetInt("level", currentLevel); 
                                                            
            PlayerPrefs.Save();

        }
            
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > currentLevel) 
            {
                 lvlButtons[i].interactable = false;
            }
               
        }
        //Debug.Log(levelAt);
    }
    
    //public static int level;

    

    /*public void resetPlayerPrefs()
    {
        Level1Button.interactable = false;
        Level2Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }*/


    void Update() {
        int currentLevel = PlayerPrefs.GetInt("level");
        //Debug.Log("I am in Levelselection: Line 45" + currentLevel);
        /*if (myLevel == 3)
        {
            lvlButtons[1].interactable = true;
        }
        if (myLevel == 4)
        {
            lvlButtons[2].interactable = true;
        }*/
        if (currentLevel == 3)
        {
            lvlButtons[0].interactable = true;
        }
        if (currentLevel == 4)
        {
            lvlButtons[1].interactable = true;

        }

    }   
    public void RestartButton()
    {
    
        if(PlayerPrefs.HasKey("level")) 
        {
            PlayerPrefs.SetInt("level", 0);
            PlayerPrefs.Save();
            lvlButtons[0].interactable = true;
            lvlButtons[1].interactable = false;
        }

            
        
        
        // add one more if statement and attribute theload next levl script to the finish line if a new level is added

    }

}
