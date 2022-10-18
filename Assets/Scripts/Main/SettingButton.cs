using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] MainSM mainSM;

    private void OnMouseDown()
    {
        mainSM.SettingOFF();

    }
}
