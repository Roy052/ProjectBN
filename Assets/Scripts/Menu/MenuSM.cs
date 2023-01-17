using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSM : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI newGameText, continueText, settingText, quitText;
    [SerializeField] GameObject newGameButton, continueButton, settingButton, quitButton;

    public SettingManager settingManager;
    bool setON = false;

    string[,] texts = new string[2, 4] { 
        { "New Game", "Continue", "Setting", "Quit" }, 
        { "새 게임", "이어하기", "설정", "종료" } };
    int languageType = 0;

    public GameManager gm;
    bool isSaveExist = false;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (SaveDataScript.LoadFromJson() != null)
            isSaveExist = true;

        if (isSaveExist == false)
            continueButton.gameObject.SetActive(false);
        ChangeLanguage(gm.languageType);
        settingManager.SettingOFF();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && setON == true)
            SettingOFF();
    }
    public void ChangeLanguage(int type)
    {
        languageType = type;
        newGameText.text = texts[languageType, 0];
        continueText.text = texts[languageType, 1];
        if (isSaveExist == false)
            continueText.color = Color.gray;
        settingText.text = texts[languageType, 2];
        quitText.text = texts[languageType, 3];
    }
    public void SettingON()
    {
        settingManager.SettingON();
        setON = true;
    }

    public void SettingOFF()
    {
        settingManager.SettingOFF();
        setON = false;
    }
}
