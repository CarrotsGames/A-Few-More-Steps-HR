using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Slider soundEffectSlider;
    public Slider musicSlider;
    public Text qualityText;
    public GameObject pauseMenu;
    public GameObject audioManager;
    int qualityInt;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        if(audioManager == null)
        {
            Debug.LogError("No audioSource???");
        }
        if (pauseMenu == null)
        {
            Debug.LogError("pause menu not assigned to settings dumbo!!!!");
        }
        qualityInt = PlayerPrefs.GetInt("Quality");
        soundEffectSlider.value = audioManager.GetComponent<AudioManager>().soundSource.volume;
        musicSlider.value = audioManager.GetComponent<AudioManager>().musicSource.volume;
        Quality();
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouseUP");
            audioManager.GetComponent<AudioManager>().soundSource.volume = soundEffectSlider.value;
            audioManager.GetComponent<AudioManager>().musicSource.volume = musicSlider.value;
        }
    }
    public void Left()
    {
        qualityInt--;
        if(qualityInt < 0)
        {
            qualityInt = 1;
        }
        Quality();
    }
    public void Right()
    {
        qualityInt++;
        if (qualityInt > 1)
        {
            qualityInt = 0;
        }
        Quality();
    }
    void Quality()
    {
        PlayerPrefs.SetInt("Quality", qualityInt);
        switch(qualityInt)
        {
            case 0:        
                QualitySettings.SetQualityLevel(0);
                qualityText.text = "Low";
                break;
            case 1:
                QualitySettings.SetQualityLevel(1);
                qualityText.text = "High";

                break;
        }
    }
    public void BackToPause()
    {
        this.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
