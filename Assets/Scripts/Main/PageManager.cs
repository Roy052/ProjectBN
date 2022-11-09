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
    [SerializeField] Image image_AgendaCase;
    [SerializeField] Text text_AgendaCase;
    [SerializeField] TextMeshProUGUI[] optionTexts;

    int pageNum = 0;
    public int maxPageNum = 3;
    public MainSM mainSM;

    GameData gameData = new GameData();

    //Result
    [SerializeField] TextMeshProUGUI resultHeadline;
    [SerializeField] TextMeshProUGUI resultContent;

    //Agenda
    int eventNum = 0;
    int selectedNum_Agenda = -1;
    public OptionBox[] optionBoxes;

    //Case&Accident
    int caseNum = 0;
    int selectedNum_Case = -1;

    //Decision
    [SerializeField] TextMeshProUGUI decisionSummary;
    [SerializeField] GameObject decisionButton;
    [SerializeField] TextMeshProUGUI decisionText;

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

    public void OptionSelected_Case(int num)
    {
        if (selectedNum_Case != -1)
        {
            optionTexts[selectedNum_Case].color = new Color(0, 0, 0);
            optionBoxes[selectedNum_Case].selected = false;
        }

        selectedNum_Case = num;
        optionTexts[num].color = new Color(0.7f, 0, 0);
    }
    
    public bool IsOptionSelected()
    {
        if (selectedNum_Agenda == -1 || selectedNum_Case == -1) return false;
        else return true;
    }

    public void RefreshPage()
    {
        pageNum = 0;
        selectedNum_Agenda = -1;
        selectedNum_Case = -1;
        decisionButton.GetComponent<DecisionButton>().saved = false;
        for(int i = 0; i < 3; i++)
        {
            optionTexts[i].color = new Color(0, 0, 0);
            optionBoxes[i].selected = false;
        }
    }

    public void LogAgenda()
    {
        mainSM.LogAgenda(eventNum, selectedNum_Agenda);
        mainSM.LogCase(caseNum, selectedNum_Case);
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

        image_AgendaCase.gameObject.SetActive(true);
        text_AgendaCase.gameObject.SetActive(true);
        text_AgendaCase.text = "Agenda!";

        //Options
        for (int i = 0; i < 3; i++)
        {
            optionTexts[i].gameObject.SetActive(true);
            optionTexts[i].text = gameData.options[languageType, eventNum, i];
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

    //Case
    private void ThirdPage()
    {
        RemovePageContent();

        image_AgendaCase.gameObject.SetActive(true);
        text_AgendaCase.gameObject.SetActive(true);
        text_AgendaCase.text = "Case!";

        //Options
        for (int i = 0; i < 3; i++)
        {
            optionTexts[i].gameObject.SetActive(true);
            optionTexts[i].text = gameData.options[languageType, eventNum, i];
            if (i == selectedNum_Case)
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

        //Summary
        decisionSummary.gameObject.SetActive(true);
        string contentText = "";
        contentText += "Agenda!" + " : " + (selectedNum_Agenda  + 1) + " Option" + "\n";
        contentText += "Case!" + " : " + (selectedNum_Case + 1) + " Option" + "\n";

        decisionSummary.text = contentText;

        //Decision
        decisionButton.SetActive(true);
        decisionText.gameObject.SetActive(true);
        if (languageType == 0) decisionText.text = "Decision";
        else decisionText.text = "°áÁ¤";
        if (selectedNum_Agenda == -1) decisionText.color = new Color(0.7f, 0, 0);
        else decisionText.color = new Color(0, 0, 0);
    }

    private void RemovePageContent()
    {
        //First
        resultHeadline.gameObject.SetActive(false);
        resultContent.gameObject.SetActive(false);

        //Second & Third
        image_AgendaCase.gameObject.SetActive(false);
        text_AgendaCase.gameObject.SetActive(false);
        for (int i = 0; i < 3; i++)
            optionTexts[i].gameObject.SetActive(false);

        //Fourth
        decisionSummary.gameObject.SetActive(false);
        decisionButton.SetActive(false);
        decisionText.gameObject.SetActive(false);
    }
}
