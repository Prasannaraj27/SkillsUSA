using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelWhenlClicked : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);//change name when button clicked function runs to name in buildManager 
        //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click); // Sfx for music not working(gave up)
    }

}
