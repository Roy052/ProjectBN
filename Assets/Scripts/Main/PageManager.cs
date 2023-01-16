using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject pageBeforeBtn, pageNextBtn, pageOFFBtn, pageOFFBtn2;
    [SerializeField] GameObject[] pageTags;

    //Contents
    //Agenda
    [SerializeField] Image image_Agenda;
    [SerializeField] Text text_Agenda_Headline, text_Agenda_Contents;

    //Incident
    [SerializeField] Image image_Incident;
    [SerializeField] Text text_Incident_Headline, text_Incident_Contents;

    //Options
    [SerializeField] TextMeshProUGUI[] optionTexts;

    int pageNum = 0;
    public int maxPageNum = 3;
    public MainSM mainSM;

    //Data
    GameData gameData = new GameData();
    IncidentData incidentData = new IncidentData();
    AgendaData agendaData = new AgendaData();

    //Result
    [SerializeField] TextMeshProUGUI resultHeadline;
    [SerializeField] TextMeshProUGUI resultContent, resultContent_Response;

    //Agenda
    int agendaNum = 0;
    int selectedNum_Agenda = -1;
    public OptionBox[] optionBoxes;

    //incident&Accident
    int incidentNum = 0;
    int selectedNum_Incident = -1;
    bool[] isOptionActivate_Agenda = new bool[3];
    bool[] isOptionActivate_Incident = new bool[3];

    //Decision
    [SerializeField] TextMeshProUGUI decisionSummaryAgendaHead, decisionSummaryAgenda, decisionSummaryAgendaChoice;
    [SerializeField] TextMeshProUGUI decisionSummaryIncidentHead, decisionSummaryIncident, decisionSummaryIncidentChoice;
    [SerializeField] GameObject decisionButton;
    [SerializeField] TextMeshProUGUI decisionText;
    string[,] agendaIncidentHead = { { "Agenda", "정책" }, { "Incident", "사건/사고" } };
    string[] unselectedText = { "Unselected", "선택하지 않음" };
    string[] selectedText = { "Your choice : ", "당신의 선택 : " };

    GameManager gm;
    int languageType = 0;
    List<int[]> currentLogData;
    
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        languageType = gm.languageType;
        PageOFF();
    }
    public void PageON()
    {
        this.gameObject.SetActive(true);
        languageType = gm.languageType;

        //Result
        if(currentLogData == null)
        {
            currentLogData = new List<int[]>();

            int length = mainSM.logManager.SaveLogLength();
            int[,] logData = mainSM.logManager.SaveLogData();

            if (length != 0)
            {
                ///if incident occur
                if (logData[length - 1, 0] != 0)
                    currentLogData.Add(new int[4] { logData[length - 2, 0], logData[length - 2, 1], logData[length - 2, 2], logData[length - 2, 3] });
                currentLogData.Add(new int[4] { logData[length - 1, 0], logData[length - 1, 1], logData[length - 1, 2], logData[length - 1, 3] });
            }
        }
        

        //AgendaNum IncidentNum
        agendaNum = mainSM.agendaIncidentManager.CurrentAgenda();
        incidentNum = mainSM.agendaIncidentManager.CurrentIncident();
        Debug.Log("IncidentNum = " + incidentNum);

        //OptionCount to isOptionActivate
        for (int i = 0; i < 3; i++)
        {
            if (i >= agendaData.optionCount[agendaNum]) isOptionActivate_Agenda[i] = false;
            else isOptionActivate_Agenda[i] = true;
        }

        for (int i = 0; i < 3; i++)
        {
            if (i >= incidentData.optionCount[incidentNum]) isOptionActivate_Incident[i] = false;
            else isOptionActivate_Incident[i] = true;
        }

        Debug.Log(incidentData.optionCount[incidentNum] + ", " + isOptionActivate_Incident[0] + ", " + isOptionActivate_Incident[1]);

        if(isOptionActivate_Incident[0] == false) selectedNum_Incident = -2;

        PageChange();
    }
    public void PageOFF()
    {
        this.gameObject.SetActive(false);
    }
    public void NextPage()
    {
        pageNum++;
        PageChange();
    }
    public void BeforePage()
    {
        pageNum--;
        PageChange();
    }

    public void GotoPage(int num)
    {
        pageNum = num;
        PageChange();
    }

    void PageChange()
    {
        //Tag
        for(int i = 0; i < pageTags.Length; i++)
        {
            if(pageNum == i)
                pageTags[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
            else
                pageTags[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }

        //PageBtn
        if (pageNum == 0)
        {
            pageNextBtn.SetActive(true);
            pageBeforeBtn.SetActive(false);
        }
        else if (pageNum == maxPageNum - 1)
        {
            pageNextBtn.SetActive(false);
            pageBeforeBtn.SetActive(true);
        }
        else
        {
            pageNextBtn.SetActive(true);
            pageBeforeBtn.SetActive(true);
        }

        if (pageNum == 0)
            FirstPage();
        else if (pageNum == 1)
            SecondPage();
        else if (pageNum == 2)
            ThirdPage();
        else
            FourthPage();
    }

    public void OptionON(int num)
    {
        optionTexts[num].color = new Color(0.3f, 0.3f, 0.3f);
    }

    public void OptionOFF(int num)
    {
        optionTexts[num].color = new Color(0, 0, 0);
    }

    public void OptionSelected_Agenda(int num)
    {
        if (selectedNum_Agenda != -1)
        {
            optionTexts[selectedNum_Agenda].color = new Color(0, 0, 0);
            optionBoxes[selectedNum_Agenda].selected = false;
        }

        selectedNum_Agenda = num;
        optionTexts[num].color = new Color(0.7f, 0, 0);
    }

    public void OptionSelected_Incident(int num)
    {
        if (selectedNum_Incident != -1)
        {
            optionTexts[selectedNum_Incident].color = new Color(0, 0, 0);
            optionBoxes[selectedNum_Incident].selected = false;
        }

        selectedNum_Incident = num;
        optionTexts[num].color = new Color(0.7f, 0, 0);
    }
    
    public bool IsOptionSelected()
    {
        if (selectedNum_Agenda == -1 || selectedNum_Incident == -1) return false;
        else return true;
    }

    public void RefreshPage()
    {
        pageNum = 0;

        selectedNum_Agenda = -1;
        selectedNum_Incident = -1;
        decisionButton.GetComponent<DecisionButton>().saved = false;

        currentLogData = null;

        for(int i = 0; i < 3; i++)
        {
            optionTexts[i].color = new Color(0, 0, 0);
            optionBoxes[i].selected = false;
        }
    }

    public void LogAgenda()
    {
        mainSM.LogAgenda(agendaNum, selectedNum_Agenda);
        mainSM.LogIncident(incidentNum, selectedNum_Incident);
    }

    //Result
    private void FirstPage()
    {
        RemovePageContent();

        //Headline
        resultHeadline.gameObject.SetActive(true);

        if(languageType == 0)
        {
            string ordinalNumber = "";
            if (gm.weeks == 1 || (gm.weeks > 20 && gm.weeks % 10 == 1)) ordinalNumber = "st";
            else if (gm.weeks == 2 || (gm.weeks > 20 && gm.weeks % 10 == 2)) ordinalNumber = "nd";
            else if (gm.weeks == 3 || (gm.weeks > 20 && gm.weeks % 10 == 3)) ordinalNumber = "rd";
            else ordinalNumber = "th";

            resultHeadline.text = gm.weeks + ordinalNumber + " Week Report";
        }
        else
        {
            resultHeadline.text = gm.weeks + "주차 리포트";
        }

        //Content
        resultContent.gameObject.SetActive(true);
        resultContent_Response.gameObject.SetActive(true);
        if (currentLogData.Count == 0)
        {
            if (languageType == 0)
                resultContent.text = "Congratulations on your inauguration as president.";
            else
                resultContent.text = "대통령 취임을 축하합니다.";
        }
        else
        {
            string resultText = "";
            string resultText_Response = "";

            foreach(int[] logData in currentLogData) //0 : agendaOrIncident, 1 : eventNum, 2 : optionNum, 3 : responseNum
            {
                if (logData[0] == 0)
                {
                    resultText += agendaData.headlines[logData[1], languageType];
                    resultText += " / ";
                    resultText += agendaData.options[logData[1] ,logData[2], languageType];
                }
                else
                {
                    resultText += incidentData.headlines[logData[1], languageType];
                    resultText += " / ";
                    resultText += incidentData.options[logData[1], logData[2], languageType];
                }

                resultText_Response += "[ R ]";

                resultText += "\n";
                resultText_Response += "\n";
            }

            resultContent.text = resultText;
            resultContent_Response.text = resultText_Response;
        }
        

    }

    //Agenda
    private void SecondPage()
    {
        RemovePageContent();

        image_Agenda.gameObject.SetActive(true);
        text_Agenda_Headline.gameObject.SetActive(true);
        text_Agenda_Contents.gameObject.SetActive(true);
        text_Agenda_Headline.text = agendaData.headlines[agendaNum, languageType];
        text_Agenda_Contents.text = agendaData.contents[agendaNum, languageType];

        //Options
        for (int i = 0; i < 3; i++)
        {
            //No more option
            if (isOptionActivate_Agenda[i] == false) break;

            optionTexts[i].gameObject.SetActive(true);
            optionBoxes[i].gameObject.SetActive(true);

            optionTexts[i].text = agendaData.options[agendaNum, i, languageType];
            if (i == selectedNum_Agenda)
            {
                optionBoxes[i].selected = true;
                optionTexts[i].color = new Color(0.7f, 0, 0);
            }
            else
            {
                optionBoxes[i].selected = false;
                optionTexts[i].color = new Color(0, 0, 0);
            }

            optionBoxes[i].type = 0;
        }
    }

    //incident
    private void ThirdPage()
    {
        RemovePageContent();

        image_Incident.gameObject.SetActive(true);
        text_Incident_Headline.gameObject.SetActive(true);
        text_Incident_Contents.gameObject.SetActive(true);
        text_Incident_Headline.text = incidentData.headlines[incidentNum, languageType];
        text_Incident_Contents.text = incidentData.contents[incidentNum, languageType];

        //Options
        for (int i = 0; i < 3; i++)
        {
            //No more option
            if (isOptionActivate_Incident[i] == false) break;

            optionTexts[i].gameObject.SetActive(true);
            optionBoxes[i].gameObject.SetActive(true);

            optionTexts[i].text = incidentData.options[incidentNum, i, languageType];
            if (i == selectedNum_Incident)
            {
                optionBoxes[i].selected = true;
                optionTexts[i].color = new Color(0.7f, 0, 0);
            }
            else
            {
                optionBoxes[i].selected = false;
                optionTexts[i].color = new Color(0, 0, 0);
            }
            optionBoxes[i].type = 1;
        }

        

    }
   
    //Decision
    private void FourthPage()
    {
        RemovePageContent();

        //Head
        decisionSummaryAgendaHead.gameObject.SetActive(true);
        decisionSummaryIncidentHead.gameObject.SetActive(true);
        decisionSummaryAgendaHead.text = agendaIncidentHead[0, languageType];
        decisionSummaryIncidentHead.text = agendaIncidentHead[1, languageType];

        //Summary
        decisionSummaryAgenda.gameObject.SetActive(true);
        decisionSummaryIncident.gameObject.SetActive(true);
        decisionSummaryAgenda.text = agendaData.headlines[agendaNum, languageType];
        decisionSummaryIncident.text = incidentData.headlines[incidentNum, languageType];

        //Choice
        decisionSummaryAgendaChoice.gameObject.SetActive(true);
        decisionSummaryIncidentChoice.gameObject.SetActive(true);
        if (selectedNum_Agenda == -1)
            decisionSummaryAgendaChoice.text = unselectedText[languageType];
        else
            decisionSummaryAgendaChoice.text = selectedText[languageType] 
                + agendaData.options[agendaNum,selectedNum_Agenda,languageType];

        if (selectedNum_Incident == -1)
            decisionSummaryIncidentChoice.text = unselectedText[languageType];
        else
        {
            if (selectedNum_Incident == -2)
                decisionSummaryIncidentChoice.text = "";
            else
                decisionSummaryIncidentChoice.text = selectedText[languageType] + incidentData.options[incidentNum, selectedNum_Incident, languageType];
        }
            

        //Decision
        decisionButton.SetActive(true);
        decisionText.gameObject.SetActive(true);
        if (languageType == 0) decisionText.text = "Decision";
        else decisionText.text = "결정";
        if (selectedNum_Agenda == -1 || selectedNum_Incident == -1) decisionText.color = new Color(0.7f, 0, 0);
        else decisionText.color = new Color(0, 0, 0);
    }

    private void RemovePageContent()
    {
        //First
        resultHeadline.gameObject.SetActive(false);
        resultContent.gameObject.SetActive(false);
        resultContent_Response.gameObject.SetActive(false);

        //Second
        image_Agenda.gameObject.SetActive(false);
        text_Agenda_Headline.gameObject.SetActive(false);
        text_Agenda_Contents.gameObject.SetActive(false);

        //Third
        image_Incident.gameObject.SetActive(false);
        text_Incident_Headline.gameObject.SetActive(false);
        text_Incident_Contents.gameObject.SetActive(false);

        //Second & Third
        for (int i = 0; i < 3; i++)
        {
            optionTexts[i].gameObject.SetActive(false);
            optionBoxes[i].gameObject.SetActive(false);
        }

        //Fourth
        decisionSummaryAgendaHead.gameObject.SetActive(false);
        decisionSummaryIncidentHead.gameObject.SetActive(false);

        decisionSummaryAgenda.gameObject.SetActive(false);
        decisionSummaryIncident.gameObject.SetActive(false);

        decisionSummaryAgendaChoice.gameObject.SetActive(false);
        decisionSummaryIncidentChoice.gameObject.SetActive(false);

        decisionButton.SetActive(false);
        decisionText.gameObject.SetActive(false);
    }
}
