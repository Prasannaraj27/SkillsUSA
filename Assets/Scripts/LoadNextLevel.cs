using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static level.LevelSelection;
public class LoadNextLevel : MonoBehaviour

{
    public int nextSceneLoad;
    //public LevelSelection system;
    //private LevelSelection check;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1;
    }

    void Update() //dont change
    {
        if (FindObjectOfType<Player>().HasPlayerWon())
        {
            //Time.timeScale = 0;
            //canvas.enabled = true;
            //SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("level"))
            {
            
                //Debug.Log("I am in LoadNextLeve: Line 29" + PlayerPrefs.GetInt("level"));
                PlayerPrefs.SetInt("level",nextSceneLoad);
                PlayerPrefs.Save();
                // Debug.Log("inside update"+PlayerPrefs.GetInt("level"));

                //Debug.Log("I am in LoadNextLevel: Line 34" + PlayerPrefs.GetInt("level"));
            }
            
            
            /*if (nextSceneLoad > PlayerPrefs.GetInt("level"))
            {
                PlayerPrefs.SetInt("level",nextSceneLoad);
            }*/
        }    
     }


     


     
}


    


