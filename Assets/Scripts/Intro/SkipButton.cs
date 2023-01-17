using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    [SerializeField] IntroSM introSM;
    private void OnMouseDown()
    {
        introSM.gm.ToMain();
    }
}
