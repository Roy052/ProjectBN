using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float[,] pageInfo_Image = new float[4, 3] { { 0.2f, 0.2f, 0.2f }, { 0.3f, 0.3f, 0.3f }, { 0.4f, 0.4f, 0.4f }, { 0.5f, 0.5f, 0.5f } };
    public string[,] pageInfo_String = new string[2, 4] { { "Result", "Agenda", "News", "Decision" }, { "결과 창입니다.", "선택지 창입니다.", "사건사고 창입니다.", "결정 창입니다." } };
    public string[,,] options = new string[2, 1, 3] { 
        { { "1st option", "2nd option", "3rd option" } },
        { { "1번 선택지입니다.", "2번 선택지 입니다", "3번 선택지 입니다" } } 
    };

    public string[,,] endingTexts = new string[2, 1, 3]
    {
        {{"People are angry at your politics.", "They rallied to bring you down.", "You're done."} },
        {{"사람들은 당신의 정치에 분노했다.", "그들은 당신을 끌어내리기 위해 결집했다.", "당신은 끝났다."} }
    };
}
