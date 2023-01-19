using System.Collections;
using System.Collections.Generic;

public class AgendaData
{
    public string[,] headlines = 
        {
        { "Swear" ,"����" },
        {"Super PAC" , "������" },
        {"Making money" , "���ڱ� ����" },
        {"Neutral" , "�߸���" },
        {"Censorship" , "�˿�" }
    };

    public string[,] contents = 
        {
        { "I do solemnly swear. I will faithfully carry out the presidency and defend the Constitution." ,"���� ������ �ͼ��մϴ�. ���� ����� ���� ������ �����ϸ� ����� ��ȣ�� ���Դϴ�." },
        {"Super PAC on" , "������ ��å" },
        {"Making money" , "���ڱ� ������ �������� �� ���� ȸ�� ����" },
        {"Netural sengen" , "�߸��� ����" },
        {"Censorship for every contents" , "��� ��ü�� ���� �˿� ��å" }
    };

    public int[] optionCount =
    { 1, 3, 2, 3, 2};

    public string[,,] options =
    {
        { {"I Swear", "���� �����Ѵ�."}, {"", "" }, {"", "" } },
        { {"On", "����"}, {"Postpone", "����" }, {"Reject", "�ź�" } },
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
