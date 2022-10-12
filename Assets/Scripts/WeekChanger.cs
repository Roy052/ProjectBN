using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekChanger : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject blackFade, city;
    [SerializeField] TextMeshProUGUI weekText;
    [SerializeField] MainSM mainSM;
    private void Start()
    {
        StartCoroutine(WeekStart());
        if (gm.languageType == 0) weekText.text = gm.weeks + "weeks in office";
        else weekText.text = "재임 " + gm.weeks + "주차";

    }
    public IEnumerator WeekEnd()
    {
        mainSM.ABC();
        Debug.Log("B");
        gm.weeks++;
        blackFade.SetActive(true);
        StartCoroutine(FadeManager.FadeIn(blackFade.GetComponent<SpriteRenderer>(), 1));
        StartCoroutine(FadeManager.FadeIn(city.GetComponent<SpriteRenderer>(), 1));
        StartCoroutine(FadeManager.FadeIn(weekText, 1));
        yield return new WaitForSeconds(2);
        Debug.Log("C");
        StartCoroutine(WeekStart());
    }

    public IEnumerator WeekStart()
    {
        if (gm.languageType == 0) weekText.text = gm.weeks + "weeks in office";
        else weekText.text = "재임 " + gm.weeks + "주차";
        yield return new WaitForSeconds(2);
        StartCoroutine(FadeManager.FadeOut(blackFade.GetComponent<SpriteRenderer>(), 2));
        StartCoroutine(FadeManager.FadeOut(city.GetComponent<SpriteRenderer>(), 1));
        StartCoroutine(FadeManager.FadeOut(weekText, 1));
        yield return new WaitForSeconds(1);
        blackFade.SetActive(false);
    }
}
