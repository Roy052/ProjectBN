using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogButton : MonoBehaviour
{
    [SerializeField] MainSM mainSM;

    private void OnMouseDown()
    {
        mainSM.LogOFF();
    }
}
