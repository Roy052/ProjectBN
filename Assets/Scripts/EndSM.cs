using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndSM : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] texts;
    [SerializeField] Image image;

    private void Start()
    {
        
    }

    IEnumerator EndingScene()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeManager.FadeIn(image, 1));
    }
}
