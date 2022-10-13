using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int languageType = 0;
    [SerializeField] WeekChanger weekChanger;
    
    public int weeks = 1;


    public void ChangeLanguage(int type)
    {
        languageType = type;
    }

    
}
