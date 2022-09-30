using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public int type;
    public MainSM mainSM;
    private void OnMouseDown()
    {
        switch (type)
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
