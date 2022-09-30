using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButton : MonoBehaviour
{
    public int type;
    public PageManager pageManager;
    private void OnMouseDown()
    {
        if (type == 0)
            pageManager.BeforePage();
        else
            pageManager.NextPage();
    }
}
