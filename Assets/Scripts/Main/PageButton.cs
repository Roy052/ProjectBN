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
    }
}
