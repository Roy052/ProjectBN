using System.Collections;
using System.Collections.Generic;

public class AgendaData
{
    public string[,] agendaHeadlines = {
        {"Superpack" , "������" },
        {"Making money" , "���ڱ� ����" },
        {"Neutral" , "�߸���" },
        {"Censorship" , "�˿�" },
        {"Drug" , "����" }
    };

    public string[,] agendaContents = {
        {"Superpack on" , "������ ��å" },
        {"Making money" , "���ڱ� ������ �������� �� ���� ȸ�� ����" },
        {"Netural sengen" , "�߸��� ����" },
        {"Censorship for every contents" , "��� ��ü�� ���� �˿� ��å" },
        {"Drug legal" , "���� �չ�ȭ ���� ����" }
    };

    public float[,,] weight =
    {   //option 1, 2, 3
        { { 0, 0, 0, 0 }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 1, 1, 1, 1 } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } },
        { { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f }, { 0.25f, 0.25f, 0.25f, 0.25f } }
    };
}