using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Slider soundEffectSlider;
    public Slider musicSlider;
    public Text qualityText;
    public Text resoltuionScreenText;
    public Text fullScreenText;

    public GameObject pauseMenu;
    public GameObject audioManager;
    public bool fullScreen = true;
    int qualityInt;
    int resolutionInt;
    int fullScreenInt;

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
        resolutionInt = PlayerPrefs.GetInt("Resolution");
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
    //QUALITY SETTINGS
    public void QualityLeft()
    {
        qualityInt--;
        if(qualityInt < 0)
        {
            qualityInt = 1;
        }
        Quality();
    }
    public void QualityRight()
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
    // FULL SCREEN SETTINGS
    public void FullscreenLeft()
    {
        fullScreenInt--;
        if (fullScreenInt < 0)
        {
            fullScreenInt = 1;
        }
        FullScreen();
    }
    public void FullscreenRight()
    {
        fullScreenInt++;
        if (fullScreenInt > 1)
        {
            fullScreenInt = 0;
        }
        FullScreen();
    }
    void FullScreen()
    {
        if(fullScreenInt < 1)
        {
            fullScreenText.text = "Windowed";
            fullScreen = false;
        }
        else
        {
            fullScreen = true;
            fullScreenText.text = "Fullscreen";
        }
    }
    //RESOLUTION SETTINGS
    public void ResolutionLeft()
    {
        resolutionInt--;
        if (resolutionInt < 0)
        {
            resolutionInt = 5;
        }
        Resolution();
    }
    public void ResolutionRight()
    {
        resolutionInt++;
        if (resolutionInt > 5)
        {
            resolutionInt = 0;
        }
        Resolution();
    }
    void Resolution()
    {
        PlayerPrefs.SetInt("Resolution", resolutionInt);
        switch (resolutionInt)
        {
            case 0:
                Screen.SetResolution(800, 600, fullScreen);
                resoltuionScreenText.text = "800 x 600";
                break;
            case 1:
                Screen.SetResolution(1024, 768, fullScreen);
                resoltuionScreenText.text = "1024 x 768";
                break;
            case 2:
                Screen.SetResolution(1280, 720, fullScreen);
                resoltuionScreenText.text = "1280 x 720";
                break;
            case 3:
                Screen.SetResolution(1360, 768, fullScreen);
                resoltuionScreenText.text = "1360 x 768";
                break;
            case 4:
                Screen.SetResolution(1440, 900, fullScreen);
                resoltuionScreenText.text = "1440 x 900";
                break;
            case 5:
                Screen.SetResolution(1680, 1050, fullScreen);
                resoltuionScreenText.text = "1680 x 1050";
                break;
        }
    }
    public void BackToPause()
    {
        this.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
