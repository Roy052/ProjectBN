using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButton : MonoBehaviour
{
    public int type;
    [SerializeField] PageManager pageManager;
    [SerializeField] MainSM mainSM;
    [SerializeField] WeekChanger weekChanger;

    private void OnMouseDown()
    {
        if (type == 0)
            pageManager.BeforePage();
        else if (type == 1)
            pageManager.NextPage();
        else if(type == 2)
        {
            mainSM.UIObjectOFF();
            pageManager.PageOFF();
        }
        else if(type == 3)
        {
            pageManager.GotoPage(0);
        }    
        else if(type == 4)
        {
            pageManager.GotoPage(1);
        }
        else if(type == 5)
        {
            if(pageManager.IsOptionSelected())
                StartCoroutine(weekChanger.WeekEnd());
        }
    }
}
