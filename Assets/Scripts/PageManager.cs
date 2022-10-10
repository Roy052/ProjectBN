using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject pageBeforeBtn, pageNextBtn, pageOFFBtn, pageOFFBtn2;
    [SerializeField] GameObject[] pageTags;

    //Contents
    public Image image;
    public Text text;

    int pageNum = 0;
    public int maxPageNum = 3;
    public MainSM mainSM;

    GameData gameData = new GameData();

    private void Start()
    {
        PageOFF();
    }
    public void PageON()
    {
        pageNextBtn.SetActive(true);
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        pageOFFBtn.SetActive(true);
        for (int i = 0; i < pageTags.Length; i++)
            pageTags[i].SetActive(true);

        //Tag
        if (pageNum == 0)
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        //Page Data
        Color colortemp = new Color(gameData.pageInfo_Image[pageNum, 0], gameData.pageInfo_Image[pageNum, 1], gameData.pageInfo_Image[pageNum, 2]);
        image.color = colortemp;
        text.text = gameData.pageInfo_String[pageNum];
    }
    public void PageOFF()
    {
        pageBeforeBtn.SetActive(false);
        pageNextBtn.SetActive(false);
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        pageOFFBtn.SetActive(false);
        for (int i = 0; i < pageTags.Length; i++)
            pageTags[i].SetActive(false);
    }
    public void NextPage()
    {
        pageNum++;

        //PageBtn
        if (pageNum == 1) pageBeforeBtn.SetActive(true);
        else if (pageNum == maxPageNum - 1) pageNextBtn.SetActive(false);

        //Tag
        if (pageNum == 0)
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        
        Color colortemp = new Color(gameData.pageInfo_Image[pageNum, 0], gameData.pageInfo_Image[pageNum, 1], gameData.pageInfo_Image[pageNum, 2]);
        image.color = colortemp;
        text.text = gameData.pageInfo_String[pageNum];
    }
    public void BeforePage()
    {
        pageNum--;

        //PageBtn
        if (pageNum == 0) pageBeforeBtn.SetActive(false);
        else if (pageNum == maxPageNum - 2) pageNextBtn.SetActive(true);

        //Tag
        if (pageNum == 0)
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        Color colortemp = new Color(gameData.pageInfo_Image[pageNum,0], gameData.pageInfo_Image[pageNum, 1], gameData.pageInfo_Image[pageNum, 2]);
        image.color = colortemp;
        text.text = gameData.pageInfo_String[pageNum];
    }

    public void GotoPage(int num)
    {
        pageNum = num;

        //Tag
        if (pageNum == 0)
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            pageTags[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            pageTags[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        //PageBtn
        if (pageNum == 0)
        {
            pageNextBtn.SetActive(true);
            pageBeforeBtn.SetActive(false);
        }
        else if (pageNum == maxPageNum - 1)
        {
            pageNextBtn.SetActive(true);
            pageBeforeBtn.SetActive(false);
        }
        else
        {
            pageNextBtn.SetActive(true);
            pageBeforeBtn.SetActive(true);
        }

        Color colortemp = new Color(gameData.pageInfo_Image[pageNum, 0], gameData.pageInfo_Image[pageNum, 1], gameData.pageInfo_Image[pageNum, 2]);
        image.color = colortemp;
        text.text = gameData.pageInfo_String[pageNum];
    }
}
