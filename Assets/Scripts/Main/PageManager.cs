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
    [SerializeField] Image image;
    [SerializeField] Text text;
    [SerializeField] TextMeshProUGUI[] optionTexts;

    int pageNum = 0;
    public int maxPageNum = 3;
    public MainSM mainSM;

    GameData gameData = new GameData();

    //Agenda
    int eventNum = 0;
    int selectedNum = -1;
    public OptionBox[] optionBoxes;

    //Decision
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

        Color colortemp = new Color(gameData.pageInfo_Image[pageNum, 0], gameData.pageInfo_Image[pageNum, 1], gameData.pageInfo_Image[pageNum, 2]);
        image.color = colortemp;
        text.text = gameData.pageInfo_String[languageType, pageNum];

        //Options
        if (pageNum == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                optionTexts[i].gameObject.SetActive(true);
                optionTexts[i].text = gameData.options[languageType, eventNum, i];
            }
                
        }
        else
        {
            for (int i = 0; i < 3; i++)
                optionTexts[i].gameObject.SetActive(false);
        }

        //Decision
        if(pageNum == maxPageNum - 1)
        {
            decisionButton.SetActive(true);
            decisionText.gameObject.SetActive(true);
            if (languageType == 0) decisionText.text = "Decision";
            else decisionText.text = "°áÁ¤";
            if (selectedNum == -1) decisionText.color = new Color(0.7f, 0, 0);
            else decisionText.color = new Color(0, 0, 0);
        }
        else
        {
            decisionButton.SetActive(false);
            decisionText.gameObject.SetActive(false);
        }
    }

    public void OptionON(int num)
    {
        optionTexts[num].color = new Color(0.3f, 0.3f, 0.3f);
    }

    public void OptionOFF(int num)
    {
        optionTexts[num].color = new Color(0, 0, 0);
    }

    public void OptionSelected(int num)
    {
        if (selectedNum != -1)
        {
            optionTexts[selectedNum].color = new Color(0, 0, 0);
            optionBoxes[selectedNum].selected = false;
        }

        selectedNum = num;
        optionTexts[num].color = new Color(0.7f, 0, 0);
    }
    
    public bool IsOptionSelected()
    {
        if (selectedNum == -1) return false;
        else return true;
    }

    public void RefreshPage()
    {
        pageNum = 0;
        selectedNum = -1;
        decisionButton.GetComponent<DecisionButton>().saved = false;
        for(int i = 0; i < 3; i++)
        {
            optionTexts[i].color = new Color(0, 0, 0);
            optionBoxes[i].selected = false;
        }
    }

    public void LogAgenda()
    {
        mainSM.LogAgenda(eventNum, selectedNum);
    }
}
