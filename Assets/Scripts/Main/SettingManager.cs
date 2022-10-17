using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI headText, languageHead, volumeHead;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }

        ChangeLanguage(gameManager.languageType);
    }

    public void PauseOFF()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }

    public void ChangeLanguage(int type)
    {
        if (type == 0)
        {
            headText.text = "Setting";
            languageHead.text = "Select Language";
            volumeHead.text = "Volume";
        }
        else
        {
            headText.text = "설정";
            languageHead.text = "언어 선택";
            volumeHead.text = "볼륨";
        }

        gameManager.ChangeLanguage(type);
    }
}
