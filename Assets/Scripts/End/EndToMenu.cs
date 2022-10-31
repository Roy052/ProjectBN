using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndToMenu : MonoBehaviour
{
    GameManager gm;
    bool clicked = false;
    [SerializeField] EndSM endSM;
    [SerializeField] Image dark;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnMouseDown()
    {
        if (clicked == false)
        {
            StartCoroutine(ToMenu());
            clicked = true;
        }
        
    }

    IEnumerator ToMenu()
    {
        endSM.SkipScene();
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeManager.FadeIn(dark, 1));
        yield return new WaitForSeconds(1f);
        gm.ToMenu();
    }
}
