using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScreen : MonoBehaviour
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().isDead())
        {
            canvas.enabled = true;
        }
    }


    public void Restart()
    {
        canvas.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
