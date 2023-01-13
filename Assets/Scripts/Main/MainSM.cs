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

    //AgendaIncidentManager
    public AgendaIncidentManager agendaIncidentManager;

    void Start()
    {
        LogOFF();
        AgendaOFF();
        SettingOFF();

        LoadData();
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

        int agendaResult;

        if (Mathf.Abs(tempSum - randNum) < 0.2f)
            agendaResult = 1; //Neutral
        else if (tempSum > randNum)
            agendaResult = 0; //Positive
        else
            agendaResult = 2; //Negative

        logManager.CreateLog(1, agendaNum, optionNum, agendaResult);

        StartCoroutine(agendaIncidentManager.DelayedStatusChange(1, agendaNum, agendaResult, 0.5f));
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

        int incidentResult;

        if (Mathf.Abs(tempSum - randNum) < 0.2f)
            incidentResult = 1; //Neutral
        else if (tempSum > randNum)
            incidentResult = 0; //Positive
        else
            incidentResult = 2; //Negative

        logManager.CreateLog(0, incidentNum, optionNum, incidentResult);

        StartCoroutine(agendaIncidentManager.DelayedStatusChange(0, incidentNum, incidentResult, 0.5f));
    }

    void LoadData()
    {
        SaveData saveData = SaveDataScript.LoadFromJson();
        if(saveData == null)
        {
            SaveDataScript.CreateSaveData();
            //Status Manager
            statusManager.SetStatus(new float[4] { 0.5f, 0.5f, 0.5f, 0.5f });

            //AgendaIncidentManager
            agendaIncidentManager.LoadAgendaIncidentList(null, null);

            return;
        }

        //StatusManager
        statusManager.SetStatus(saveData.status);

        //LogManager
        //1D array to 2D array
        int[,] logData = new int[100, 4];

        for(int i = 0; i < saveData.logLength; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                logData[i, j] = saveData.logData[i * 4 + j];
            }
        }

        logManager.LoadLog(saveData.logLength, logData);

        //AgendaIncidentManager
        agendaIncidentManager.LoadAgendaIncidentList(saveData.agendaList, saveData.incidentList);
    }

    public void SaveData()
    {
        float[] status;
        int logLength;
        int[] logData;
        int[] agendaList;
        int[] incidentList;


        //StatusManager
        status = statusManager.GetStatus();

        //LogManager
        logLength = logManager.SaveLogLength();
        logData = new int[400];
        int[,] logData2D = logManager.SaveLogData();
        //2D array to 1D array
        for (int i = 0; i < logLength; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                logData[i * 4 + j] = logData2D[i, j];
            }
        }

        //AgendaIncidentManager
        agendaList = agendaIncidentManager.SaveAgendaList();
        incidentList = agendaIncidentManager.SaveIncidentList();

        //Save
        //SaveDataScript.SaveIntoJson(status, logLength, logData, agendaList, incidentList);
    }
}
