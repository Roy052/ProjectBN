using System.Collections;
using System.Collections.Generic;

public class IncidentData
{
    public string[,] headlines = {
        {"Nothing happen", "���/��� ������"},
        {"Fire" , "ȭ��" },
        {"Olympic" , "�ø���" },
        {"Terror" , "�׷�" },
        {"Serial killer" , "�������" }
    };

    public string[,] contents = {
        {"Nothing happen", "���/��� ������"},
        {"Fire it up. Lets burn" , "ȭ�簡 �߻��ߴ�. ���� ��ð����� ����" },
        {"Olympic open" , "�ø����� �����ϰԵǾ���." },
        {"Bomb terror occured" , "��ź �׷��� �߻��ߴ�" },
        {"Uncatched serial killer" , "���� ���� ����� �߻��ߴ�. ������ ���� ������ �ʾҴ�." }
    };

    public int[] optionCount =
    { 0, 3, 2, 3, 2};

    public string[,,] options =
    {
        { {"", ""}, {"", "" }, {"", "" } },
        { {"On", "����"}, {"Postpone", "����" }, {"Reject", "�ź�" } },
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
