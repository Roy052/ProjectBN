using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float[,] pageInfo_Image = new float[3, 3] { { 0.2f, 0.2f, 0.2f }, { 0.3f, 0.3f, 0.3f }, { 0.4f, 0.4f, 0.4f } };
    public string[,] pageInfo_String = new string[2, 3] { { "Result", "Agenda", "Mol?Ru" }, { "결과 창입니다.", "선택지 창입니다.", "몰루입니다." } };
    public string[,,] options = new string[2, 1, 3] { 
        { { "1st option", "2nd option", "3rd option" } },
        { { "1번 선택지입니다.", "2번 선택지 입니다", "3번 선택지 입니다" } } 
    };
}
