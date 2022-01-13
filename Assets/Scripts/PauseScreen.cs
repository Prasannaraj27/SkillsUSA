using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    Canvas canvas;

    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !FindObjectOfType<Player>().isDead())
        {
            gamePaused = true;
            Time.timeScale = 0;
            canvas.enabled = true;
        }
    }

    public void Resume()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
        gamePaused = false;
    }

    /*public void Restart()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
        gamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }*/

    public void Quit()
    {
        Time.timeScale = 1;
        gamePaused = false;
        SceneManager.LoadScene("StartScreen");
    }

    public bool IsGamePaused()
    {
        return gamePaused;
    }
}
