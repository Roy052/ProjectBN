using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButton : MonoBehaviour
{
    public int type;
    public PageManager pageManager;
    public MainSM mainSM;
    private void OnMouseDown()
    {
        if (type == 0)
            pageManager.BeforePage();
        else if (type == 1)
            pageManager.NextPage();
        else
        {
            mainSM.UIObjectOFF();
            pageManager.PageOFF();
        }
            
    }
}
