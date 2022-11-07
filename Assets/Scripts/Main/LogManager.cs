using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogManager : MonoBehaviour
{
    [SerializeField] GameObject logTemplate;
    [SerializeField] Transform logTransform;
    [SerializeField] TextMeshProUGUI[] tableHead;
    string[,] tableHeadTexts = new string[2, 3] { {"Agenda", "Choice", "Response" }, { "제안 내용", "선택", "반응" } };
    string[,] responseTexts = new string[2, 3] { { "Positive", "Negative", "Neutral" }, { "긍정적", "부정적", "중립적" } };
    int languageType = 0;
    GameManager gm;
    private void Start()
    {
        /*
        for(int i = 0; i < 30; i++)
        {
            GameObject temp = Instantiate(logTemplate, logTransform);
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i + "st agenda";
            temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = i + "st option";
            temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "[Negative]";
        }
        */
        LogOpen();
    }

    public void LogOpen()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ChangeLanguage(gm.languageType);
    }

    public void ChangeLanguage(int type)
    {
        languageType = type;
        for (int i = 0; i < 3; i++)
            tableHead[i].text = tableHeadTexts[languageType, i];
    }

    public void CreateLog(int agendaNum, int optionNum, int responseNum)
    {
        GameObject temp = Instantiate(logTemplate, logTransform);
        temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (agendaNum + 1) + "st agenda";
        temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (optionNum + 1) + "st option";

        string tempStr = "[" + responseTexts[languageType, responseNum] + "]";
        temp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = tempStr;
    }
}
