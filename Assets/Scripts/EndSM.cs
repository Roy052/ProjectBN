using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndSM : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts;
    [SerializeField] Image image;

    [SerializeField] Sprite[] endSprites;
    int endingNum = 0;
    int languageType = 0;
    GameData gameData = new GameData();
    private void Start()
    {
        image.sprite = endSprites[endingNum];
        image.gameObject.SetActive(false);
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
            texts[i].text = gameData.endingTexts[languageType, endingNum, i];
        }
        StartCoroutine(EndingScene());
    }

    IEnumerator EndingScene()
    {
        yield return new WaitForSeconds(1);
        image.gameObject.SetActive(true);
        StartCoroutine(FadeManager.FadeIn(image, 1));
        yield return new WaitForSeconds(3);
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(true);
            StartCoroutine(FadeManager.FadeIn(texts[i], 1));
            yield return new WaitForSeconds(3);
        }
        
    }
}
