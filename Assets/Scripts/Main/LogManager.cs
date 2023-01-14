using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogManager : MonoBehaviour
{
    [SerializeField] GameObject logTemplate;
    [SerializeField] Transform logTransform;
    [SerializeField] TextMeshProUGUI[] tableHead;

    //Datas
    string[,] tableHeadTexts = new string[4, 2] {
        {"Category", "분류" },
        {"Contents", "내용" }, 
        {"Choice", "선택" },
        {"Response", "반응" }
    };
    string[,] incidentAgendaTexts = new string[2, 2] { { "Incident", "사건/사고" }, { "Agenda", "정책" } };
    string[,] responseTexts = new string[3, 2] {
        { "Positive", "긍정적" },
        { "Netural", "중립적" },
        { "Negative", "부정적" }
    };
    Color[] responseColors = { new Color(0,0.6f,0), new Color(0.1f, 0.1f, 0.1f), new Color(0.6f, 0, 0) };

    IncidentData incidentData;
    AgendaData agendaData;

    //language
    int languageType = 0;
    GameManager gm;

    //LogGameObject
    List<GameObject> logObjects = new List<GameObject>();
    int logLength = 0;
    int[,] logData = new int[100, 4];

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LogOpen();
        incidentData = new IncidentData();
        agendaData = new AgendaData();
    }

    public void LoadLog(int logLength, int[,] logData)
    {
        this.logData = logData;

        for (int i = 0; i < logLength; i++)
            CreateLog((short)logData[i, 0], logData[i, 1], logData[i, 2], logData[i, 3]);
    }
    public int SaveLogLength()
    {
        return logLength;
    }

    public int[,] SaveLogData()
    {
        return logData;
    }

    public void LogOpen()
    {
        ChangeLanguage(gm.languageType);
    }

    public void ChangeLanguage(int type)
    {
        languageType = type;
        for (int i = 0; i < tableHead.Length; i++)
            tableHead[i].text = tableHeadTexts[i, languageType];
    }

    public void CreateLog(short incidentOrAgenda,int eventNum, int optionNum, int responseNum)
    {
        if (incidentOrAgenda == 0 && optionNum == -2) return;

        GameObject temp = Instantiate(logTemplate, logTransform);
        temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = incidentAgendaTexts[incidentOrAgenda, languageType];

        if (incidentOrAgenda == 0)
        {
            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = incidentData.headlines[eventNum, languageType];
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = incidentData.options[eventNum ,optionNum, languageType];
        }
        else
        {
            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = agendaData.headlines[eventNum, languageType];
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = agendaData.options[eventNum, optionNum, languageType];
        }

        string tempStr = "[" + responseTexts[responseNum, languageType] + "]";
        temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = tempStr;
        temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().color = responseColors[responseNum];

        logObjects.Add(temp);
        Debug.Log("LogDataSize : " + logData.Length);
        logData[logLength, 0] = (int)incidentOrAgenda;
        logData[logLength, 1] = eventNum;
        logData[logLength, 2] = optionNum;
        logData[logLength, 3] = responseNum;
        logLength++;
    }

    
}
