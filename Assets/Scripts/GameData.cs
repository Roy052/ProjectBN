using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float[,] pageInfo_Image = new float[4, 3] { { 0.2f, 0.2f, 0.2f }, { 0.3f, 0.3f, 0.3f }, { 0.4f, 0.4f, 0.4f }, { 0.5f, 0.5f, 0.5f } };
    public string[,] pageInfo_String = new string[2, 4] { { "Result", "Agenda", "News", "Decision" }, { "��� â�Դϴ�.", "������ â�Դϴ�.", "��ǻ�� â�Դϴ�.", "���� â�Դϴ�." } };
    public string[,,] options = new string[2, 1, 3] { 
        { { "1st option", "2nd option", "3rd option" } },
        { { "1�� �������Դϴ�.", "2�� ������ �Դϴ�", "3�� ������ �Դϴ�" } } 
    };

    public string[,,] endingTexts = new string[2, 1, 3]
    {
        {{"People are angry at your politics.", "They rallied to bring you down.", "You're done."} },
        {{"������� ����� ��ġ�� �г��ߴ�.", "�׵��� ����� ������� ���� �����ߴ�.", "����� ������."} }
    };
}
