using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBox : MonoBehaviour
{
    public int num;
    public PageManager pm;
    public bool selected = false;
    private void OnMouseEnter()
    {
        if (selected == false)
            pm.OptionON(num);
    }

    private void OnMouseExit()
    {
        if (selected == false)
            pm.OptionOFF(num);
    }

    private void OnMouseDown()
    {
        pm.OptionSelected(num);
        selected = true;
    }
}
