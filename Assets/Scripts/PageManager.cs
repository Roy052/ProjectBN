using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject pageBeforeBtn, pageNextBtn, pageOFFBtn;
    [SerializeField] GameObject[] pageTags;

    //Contents
    public Image image;
    public Text text;

    int pageNum = 0;
    public int maxPageNum = 3;
    public MainSM mainSM;
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

        text.text = pageNum + "page";
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

        Color colortemp = image.color;
        colortemp += new Color(0.1f, 0.1f, 0.1f);
        image.color = colortemp;
        text.text = pageNum + "page";
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

        Color colortemp = image.color;
        colortemp -= new Color(0.1f, 0.1f, 0.1f);
        image.color = colortemp;
        text.text = pageNum + "page";
    }
}
