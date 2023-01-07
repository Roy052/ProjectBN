using System.Collections;
using System.Collections.Generic;

public class IncidentData
{
    public string[,] incidentHeadlines = { 
        {"Fire" , "화재" },
        {"Olympic" , "올림픽" },
        {"Terror" , "테러" },
        {"Serial killer" , "연쇄살인" },
        {"Flood" , "홍수" }
    };

    public string[,] incidentContents = {
        {"Fire intern. Lets burn" , "화재가 발생했다. 불은 삽시간으로 번져" },
        {"Olympic open" , "올림픽을 개최하게되었다." },
        {"Bomb terror occured" , "폭탄 테러가 발생했다" },
        {"Uncatched serial killer" , "연쇄 살인 사건이 발생했다. 범인은 아직 잡히지 않았다." },
        {"Massive flood" , "엄청난 홍수가 해안가를 덮쳤다. 수많은 인명피해가 발생했다." }
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
