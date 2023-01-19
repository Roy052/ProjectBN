using System.Collections;
using System.Collections.Generic;

public class IncidentData
{
    public string[,] headlines = {
        {"Nothing happen", "사건/사고가 없었다"},
        {"Fire" , "화재" },
        {"Olympic" , "올림픽" },
        {"Terror" , "테러" },
        {"Serial killer" , "연쇄살인" }
    };

    public string[,] contents = {
        {"Nothing happen", "사건/사고가 없었다"},
        {"Fire it up. Lets burn" , "화재가 발생했다. 불은 삽시간으로 번져" },
        {"Olympic open" , "올림픽을 개최하게되었다." },
        {"Bomb terror occured" , "폭탄 테러가 발생했다" },
        {"Uncatched serial killer" , "연쇄 살인 사건이 발생했다. 범인은 아직 잡히지 않았다." }
    };

    public int[] optionCount =
    { 0, 3, 2, 3, 2};

    public string[,,] options =
    {
        { {"", ""}, {"", "" }, {"", "" } },
        { {"On", "실행"}, {"Postpone", "보류" }, {"Reject", "거부" } },
        { {"A", "A"}, {"B", "B" }, {"C", "C" } },
        { {"", ""}, {"", "" }, {"", "" } },
        { {"", ""}, {"", "" }, {"", "" } },
    };

    public float[,,] weight =
    {   //option 1, 2, 3
        { { 0, 0, 0, 0 }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 1, 1, 1, 1 } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } }
    };

    public float[,,] statusChange =
    {   //option 1, 2, 3
        { { 0.1f, 0.1f, 0.1f, 0.1f }, { 0, 0, 0, 0 }, { -0.1f, -0.1f, -0.1f, -0.1f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } }
    };

    public List<int>[] adjacentList = new List<int>[5]
    {
        new List<int>(){1,2},
        new List<int>(){3 },
        new List<int>(){3 },
        new List<int>(){4 },
        new List<int>(){-1 }
    };
}
