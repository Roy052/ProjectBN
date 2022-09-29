using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public int num;
    public MainSM mainSM;
    private void OnMouseDown()
    {
        switch (num)
        {
            case 0:
                mainSM.LogON();
                break;
            case 1:
                mainSM.AgendaON();
                break;
            case 2:
                mainSM.SettingON();
                break;
        }

    }
}
