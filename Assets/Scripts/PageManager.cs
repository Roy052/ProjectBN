using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public GameObject pageBeforeBtn, pageNextBtn;

    //Contents
    public Image image;
    public Text text;

    int pageNum = 0;
    public int maxPageNum = 3;
    private void Start()
    {
        PageOFF();
    }
    public void PageON()
    {
        pageNum = 0;
        pageNextBtn.SetActive(true);
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        text.text = pageNum + "page";
    }
    public void PageOFF()
    {
        pageBeforeBtn.SetActive(false);
        pageNextBtn.SetActive(false);
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
    public void NextPage()
    {
        pageNum++;
        if (pageNum == 1) pageBeforeBtn.SetActive(true);
        else if (pageNum == maxPageNum - 1) pageNextBtn.SetActive(false);
        Color colortemp = image.color;
        colortemp += new Color(0.1f, 0.1f, 0.1f);
        image.color = colortemp;
        text.text = pageNum + "page";
    }
    public void BeforePage()
    {
        pageNum--;
        if (pageNum == 0) pageBeforeBtn.SetActive(false);
        else if (pageNum == maxPageNum - 2) pageNextBtn.SetActive(true);
        Color colortemp = image.color;
        colortemp -= new Color(0.1f, 0.1f, 0.1f);
        image.color = colortemp;
        text.text = pageNum + "page";
    }
}
