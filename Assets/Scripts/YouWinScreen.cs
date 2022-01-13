using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScreen : MonoBehaviour
{
    Canvas canvas;


    void Start()
    {
        Time.timeScale = 1;
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
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
        SceneManager.LoadScene("StartScreen");
    }
}
