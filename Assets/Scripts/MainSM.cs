using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSM : MonoBehaviour
{
    // Log, Agenda, Setting, Quit
    public GameObject[] uiObjects;
    public GameObject[] uiButtons;
    public PageManager pageManager;
    
    int currentUIObject = -1;

    void Start()
    {
        LogOFF();
        AgendaOFF();
        SettingOFF();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentUIObject)
            {
                case -1:
                    break;
                case 0:
                    LogOFF();
                    break;
                case 1:
                    AgendaOFF();
                    break;
                case 2:
                    SettingOFF();
                    break;
            }
        }

    }

    public void LogON()
    {
        uiObjects[0].SetActive(true);
        currentUIObject = 0;
        UIButtonOFF();
    }
    
    public void LogOFF()
    {
        uiObjects[0].SetActive(false);
        currentUIObject = -1;
        UIButtonON();
    }

    public void AgendaON()
    {
        uiObjects[1].SetActive(true);
        pageManager.PageON();
        currentUIObject = 1;
        UIButtonOFF();
    }

    public void AgendaOFF()
    {
        uiObjects[1].SetActive(false);
        currentUIObject = -1;
        UIButtonON();
    }

    public void SettingON()
    {
        uiObjects[2].SetActive(true);
        currentUIObject = 2;
        UIButtonOFF();
    }

    public void SettingOFF()
    {
        uiObjects[2].SetActive(false);
        currentUIObject = -1;
        UIButtonON();
    }

    public void UIObjectOFF()
    {
        Debug.Log("A");
        switch (currentUIObject)
        {
            case -1:
                break;
            case 0:
                LogOFF();
                break;
            case 1:
                AgendaOFF();
                break;
            case 2:
                SettingOFF();
                break;
            default:
                break;
        }
    }

    void UIButtonON()
    {
        for(int i = 0; i < uiButtons.Length; i++)
            uiButtons[i].SetActive(true);
    }
    void UIButtonOFF()
    {
        for (int i = 0; i < uiButtons.Length; i++)
            uiButtons[i].SetActive(false);
    }

    public void AgendaEnd()
    {
        AgendaOFF();
        pageManager.RefreshPage();
    }
}
