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
        {"Category", "�з�" },
        {"Contents", "����" }, 
        {"Choice", "����" },
        {"Response", "����" }
    };
    string[,] incidentAgendaTexts = new string[2, 2] { { "Incident", "���/���" }, { "Agenda", "��å" } };
    string[,] responseTexts = new string[3, 2] {
        { "Positive", "������" },
        { "Netural", "�߸���" },
        { "Negative", "������" }
    };
    IncidentData incidentData;
    AgendaData agendaData;

    //language
    int languageType = 0;
    GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LogOpen();
        incidentData = new IncidentData();
        agendaData = new AgendaData();
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

    public void CreateLog(short incidentOrAgenda,int agendaNum, int optionNum, int responseNum)
    {
        GameObject temp = Instantiate(logTemplate, logTransform);
        temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = incidentAgendaTexts[incidentOrAgenda, languageType];

        temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (agendaNum + 1) + "st agenda";
        temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (optionNum + 1) + "st option";

        string tempStr = "[" + responseTexts[responseNum, languageType] + "]";
        temp.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = tempStr;
    }
}
