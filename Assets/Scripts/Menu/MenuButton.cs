using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButton : MonoBehaviour
{

    GameManager gm;
    [SerializeField] MenuSM menuSM;
    [SerializeField] int type;
    [SerializeField] TextMeshProUGUI text;

    private void OnMouseEnter()
    {
        text.color = Color.gray;
    }

    private void OnMouseExit()
    {
        text.color = Color.white;
    }
    private void OnMouseDown()
    {
        gm = menuSM.gm;
        if (type == 0)
        {
            gm.NewGameStart();
        }
        else if(type == 1)
        {
            gm.ContinueStart();
        }
        else if(type == 2)
        {
            menuSM.SettingON();
        }
        else
        {
            gm.GameQuit();
        }
    }

    
}
