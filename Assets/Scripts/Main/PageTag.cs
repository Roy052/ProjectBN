using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTag : MonoBehaviour
{
    public int num;
    [SerializeField] PageManager pageManager;

    private void OnMouseDown()
    {
        pageManager.GotoPage(num);
    }
}
