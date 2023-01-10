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
    [SerializeField] TextMeshProUGUI resultContent;

    //Agenda
    int agendaNum = 0;
    int selectedNum_Agenda = -1;
    public OptionBox[] optionBoxes;

    //incident&Accident
    int incidentNum = 0;
    int selectedNum_Incident = -1;

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

        string ordinalNumber = "";
        if (gm.weeks == 1 || (gm.weeks > 20 && gm.weeks % 10 == 1)) ordinalNumber = "st";
        else if (gm.weeks == 2 || (gm.weeks > 20 && gm.weeks % 10 == 2)) ordinalNumber = "nd";
        else if (gm.weeks == 3 || (gm.weeks > 20 && gm.weeks % 10 == 3)) ordinalNumber = "rd";
        else ordinalNumber = "th";

        resultHeadline.text = gm.weeks + ordinalNumber + " Week Report";

        //Content
        resultContent.gameObject.SetActive(true);
        resultContent.text = gm.weeks + ordinalNumber + " Week Content";
    }

    //Agenda
    private void SecondPage()
    {
        RemovePageContent();

        image_Agenda.gameObject.SetActive(true);
        text_Agenda_Headline.gameObject.SetActive(true);
        text_Agenda_Contents.gameObject.SetActive(true);
        text_Agenda_Headline.text = agendaData.agendaHeadlines[agendaNum, languageType];
        text_Agenda_Contents.text = agendaData.agendaContents[agendaNum, languageType];

        //Options
        for (int i = 0; i < 3; i++)
        {
            optionTexts[i].gameObject.SetActive(true);
            optionTexts[i].text = gameData.options[languageType, agendaNum, i];
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
        text_Incident_Headline.text = incidentData.incidentHeadlines[incidentNum, languageType];
        text_Incident_Contents.text = incidentData.incidentContents[incidentNum, languageType];

        //Options
        for (int i = 0; i < 3; i++)
        {
            optionTexts[i].gameObject.SetActive(true);
            optionTexts[i].text = gameData.options[languageType, agendaNum, i];
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
        decisionSummaryAgenda.text = agendaData.agendaHeadlines[agendaNum, languageType];
        decisionSummaryIncident.text = incidentData.incidentHeadlines[incidentNum, languageType];

        //Choice
        decisionSummaryAgendaChoice.gameObject.SetActive(true);
        decisionSummaryIncidentChoice.gameObject.SetActive(true);
        if (selectedNum_Agenda == -1)
            decisionSummaryAgendaChoice.text = unselectedText[languageType];
        else
            decisionSummaryAgendaChoice.text = selectedText[languageType] + (selectedNum_Agenda + 1);

        if (selectedNum_Incident == -1)
            decisionSummaryIncidentChoice.text = unselectedText[languageType];
        else
            decisionSummaryIncidentChoice.text = selectedText[languageType] + (selectedNum_Incident + 1);

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
            optionTexts[i].gameObject.SetActive(false);

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
