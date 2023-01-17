using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroSM : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] VideoPlayer introPlayer;
    bool once = false;
    float time = 0;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        introPlayer.Play();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= introPlayer.length && once == false)
        {
            once = true;
            gm.ToMain();
        }
    }
}
