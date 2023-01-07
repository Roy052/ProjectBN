using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSM : MonoBehaviour
{
    // Log, Agenda, Setting, Quit
    public GameObject[] uiObjects;
    public GameObject[] uiButtons;

    public LogManager logManager;
    public PageManager pageManager;
    public SettingManager settingManager;
    public WeekChanger weekChanger;
    

    int currentUIObject = -1;

    //Status
    public StatusManager statusManager;
    AgendaData agendaData = new AgendaData();
    IncidentData incidentData = new IncidentData();

    void Start()
    {
        LogOFF();
        AgendaOFF();
        SettingOFF();

        SaveDataScript.CreateSaveData();
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
        logManager.LogOpen();
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

    public void WeekEnd()
    {
        AgendaOFF();
        pageManager.RefreshPage();
        StartCoroutine(weekChanger.WeekEnd());
    }

    //Agenda -> Log
    public void LogAgenda(int agendaNum, int optionNum)
    {
        float[] currentStatus = statusManager.GetStatus();

        float tempSum = 0;
        for(int i = 0; i < currentStatus.Length; i++)
        {
            tempSum += currentStatus[i] * agendaData.weight[agendaNum, optionNum, i];
        }

        float randNum = Random.Range(0, 1.0f);

        if(Mathf.Abs(tempSum - randNum) < 0.2f)
            logManager.CreateLog(1, agendaNum, optionNum, 1); //Neutral
        else if(tempSum > randNum)
            logManager.CreateLog(1, agendaNum, optionNum, 0); //Positive
        else
            logManager.CreateLog(1, agendaNum, optionNum, 2); //Negative
    }

    //Case -> Log
    public void LogIncident(int incidentNum, int optionNum)
    {
        float[] currentStatus = statusManager.GetStatus();

        float tempSum = 0;
        for (int i = 0; i < currentStatus.Length; i++)
        {
            tempSum += currentStatus[i] * incidentData.weight[incidentNum, optionNum, i];
        }

        float randNum = Random.Range(0, 1.0f);

        if (Mathf.Abs(tempSum - randNum) < 0.2f)
            logManager.CreateLog(0, incidentNum, optionNum, 1); //Neutral
        else if (tempSum > randNum)
            logManager.CreateLog(0, incidentNum, optionNum, 0); //Positive
        else
            logManager.CreateLog(0, incidentNum, optionNum, 2); //Negative
    }
}
