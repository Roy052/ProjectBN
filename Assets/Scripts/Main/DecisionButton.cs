using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionButton : MonoBehaviour
{
    public bool saved;
    [SerializeField] PageManager pageManager;
    [SerializeField] MainSM mainSM;

    private void Start()
    {
        saved = false;
    }

    private void OnMouseDown()
    {
        if(saved == false)
        {
            saved = true;
            if (pageManager.IsOptionSelected())
            {
                pageManager.LogAgenda();
                mainSM.WeekEnd();
            }
        }
    }
}
