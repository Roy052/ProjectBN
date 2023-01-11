using System.Collections;
using System.Collections.Generic;

public class AgendaData
{
    public string[,] agendaHeadlines = {
        {"Superpack" , "슈퍼팩" },
        {"Making money" , "비자금 조성" },
        {"Neutral" , "중립국" },
        {"Censorship" , "검열" },
        {"Drug" , "마약" }
    };

    public string[,] agendaContents = {
        {"Superpack on" , "슈퍼팩 정책" },
        {"Making money" , "비자금 조성을 목적으로 한 유령 회사 설립" },
        {"Netural sengen" , "중립국 선언" },
        {"Censorship for every contents" , "모든 매체에 대한 검열 정책" },
        {"Drug legal" , "마약 합법화 법안 발의" }
    };

    public string[,,] agendaOptions =
    {
        { {"On", "실행"}, {"Postpone", "보류" }, {"Reject", "거부" } },
        { {"", ""}, {"", "" }, {"", "" } },
        { {"", ""}, {"", "" }, {"", "" } },
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
}
