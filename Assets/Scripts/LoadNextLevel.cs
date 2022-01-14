using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour

{
    public int nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1;
    }

    void Update() 
    {
        if (FindObjectOfType<Player>().HasPlayerWon())
        {
            //Time.timeScale = 0;
            //canvas.enabled = true;
            SceneManager.LoadScene(nextSceneLoad);
            
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt",nextSceneLoad);
            }
            
            
            
            


            
        }
    }


    

}
