using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScreen : MonoBehaviour
{
    //public int nextSceneLoad;
    Canvas canvas;
    

    void Start()
    {
        Time.timeScale = 1;
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1;
        //int playerwinsthegame = 0;
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex+1; ignore this
    }

    // Update is called once per frame
   void Update() 
    {
        if (FindObjectOfType<Player>().HasPlayerWon())
        {

            Time.timeScale = 0;
            canvas.enabled = true;
            


            
        }
    }


    public void Restart()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
