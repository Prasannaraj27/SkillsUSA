/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;


    void Start() //first line of code messes it up if you make this update
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",1); // num represents the position in the buildManager

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i+2 > levelAt)
            {
                lvlButtons[i].interactable = false;

            }

        }

        // Go to gamemanager, modify the array size and add the level button to the next element(click plus button) when a new level is added

    }
    void Update()
    {
        
        
   
        PlayerPrefs.SetInt("levelAt",GetActiveScene.buildIndex());
    }
    

}
*/