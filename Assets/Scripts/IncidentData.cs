using System.Collections;
using System.Collections.Generic;

public class IncidentData
{
    public string[,] incidentHeadlines = { 
        {"Fire" , "ȭ��" },
        {"Olympic" , "�ø���" },
        {"Terror" , "�׷�" },
        {"Serial killer" , "�������" },
        {"Flood" , "ȫ��" }
    };

    public string[,] incidentContents = {
        {"Fire intern. Lets burn" , "ȭ�簡 �߻��ߴ�. ���� ��ð����� ����" },
        {"Olympic open" , "�ø����� �����ϰԵǾ���." },
        {"Bomb terror occured" , "��ź �׷��� �߻��ߴ�" },
        {"Uncatched serial killer" , "���� ���� ����� �߻��ߴ�. ������ ���� ������ �ʾҴ�." },
        {"Massive flood" , "��û�� ȫ���� �ؾȰ��� ���ƴ�. ������ �θ����ذ� �߻��ߴ�." }
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
