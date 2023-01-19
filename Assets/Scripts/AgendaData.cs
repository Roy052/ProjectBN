using System.Collections;
using System.Collections.Generic;

public class AgendaData
{
    public string[,] headlines = 
        {
        { "Swear" ,"선서" },
        {"Super PAC" , "슈퍼팩" },
        {"Making money" , "비자금 조성" },
        {"Neutral" , "중립국" },
        {"Censorship" , "검열" }
    };

    public string[,] contents = 
        {
        { "I do solemnly swear. I will faithfully carry out the presidency and defend the Constitution." ,"나는 엄숙히 맹세합니다. 나는 대통령 직을 성실히 수행하며 헌법을 수호할 것입니다." },
        {"Super PAC on" , "슈퍼팩 정책" },
        {"Making money" , "비자금 조성을 목적으로 한 유령 회사 설립" },
        {"Netural sengen" , "중립국 선언" },
        {"Censorship for every contents" , "모든 매체에 대한 검열 정책" }
    };

    public int[] optionCount =
    { 1, 3, 2, 3, 2};

    public string[,,] options =
    {
        { {"I Swear", "나는 선서한다."}, {"", "" }, {"", "" } },
        { {"On", "실행"}, {"Postpone", "보류" }, {"Reject", "거부" } },
        { {"A", "A"}, {"B", "B" }, {"", "" } },
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
        { { -0.1f, -0.1f, -0.1f, -0.1f }, { 0, 0, 0, 0 }, { 0.1f, 0.1f, 0.1f, 0.1f } },
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
