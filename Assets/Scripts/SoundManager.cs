using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource AudioSource;

    public Slider volumeSlider;

    public GameObject ObjectMusic;

    private float MusicVolume = 1f;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent <AudioSource>();
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume",MusicVolume);
    }

    public void updateVolume(float volume)
    {
        MusicVolume = volume;
    }


}
