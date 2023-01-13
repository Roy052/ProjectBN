using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgendaIncidentManager : MonoBehaviour
{
    [SerializeField] StatusManager statusManager;

    int[] agendaList; //0 : Alreday happen, 1 : Current, 2 : Pool, 3 : Not happen
    int[] incidentList;
    AgendaData agendaData = new AgendaData();
    IncidentData incidentData = new IncidentData();

    List<int> agendaPool;
    List<int> incidentPool;

    //Current Situation
    int currentAgenda = -1, currentIncident = -1;
    private void Start()
    {
        
    }

    void AgendaPoolSetup()
    {
        agendaPool = new List<int>();

        for(int i = 0; i < agendaList.Length; i++)
        {
            if (agendaList[i] == 1) //Current
                currentAgenda = i;
            else if (agendaList[i] == 2) //Pool
                agendaPool.Add(i);
        }

    }

    void IncidentPoolSetup()
    {
        incidentPool = new List<int>();

        for (int i = 0; i < incidentList.Length; i++)
        {
            if (incidentList[i] == 1) //Current
                currentIncident = i;
            else if (incidentList[i] == 2) //Pool
                incidentPool.Add(i);
        }
    }

    public int CurrentAgenda()
    {
        //Already Picked
        if (currentAgenda != -1) return currentAgenda;

        int randPos = Random.Range(0, agendaPool.Count);
        int val = agendaPool[randPos];
        agendaPool.RemoveAt(val);
        agendaList[val] = 1;
        currentAgenda = agendaList[val];

        return val;
    }

    public int CurrentIncident()
    {
        //Already Picked
        if (currentIncident != -1) return currentIncident;

        int randPos = Random.Range(0, incidentPool.Count);
        int val = incidentPool[randPos];
        incidentPool.RemoveAt(val);
        incidentList[val] = 1;
        currentIncident = incidentList[val];

        return val;
    }

    public void WeekOff()
    {
        agendaList[currentAgenda] = 0;
        incidentList[currentIncident] = 0;
        
        foreach(int agendaNum in agendaData.agendaAdjacentList[currentAgenda])
        {
            agendaList[agendaNum] = 2;
            agendaPool.Add(agendaNum);
        }

        foreach (int incidentNum in incidentData.incidentAdjacentList[currentIncident])
        {
            incidentList[incidentNum] = 2;
            incidentPool.Add(incidentNum);
        }

        currentAgenda = -1;
        currentIncident = -1;
    }

    void Init_List_Pool()
    {
        int agendaLength = agendaData.agendaHeadlines.Length;
        int incidentLength = incidentData.incidentHeadlines.Length;

        agendaList = new int[agendaLength];
        incidentList = new int[incidentLength];

        //init list
        for (int i = 0; i < agendaLength; i++)
            agendaList[i] = 3;
        for (int i = 0; i < incidentLength; i++)
            incidentList[i] = 3;

        //init Pool
        agendaList[0] = 2;
        incidentList[0] = 2;

        agendaPool = new List<int>();
        incidentPool = new List<int>();
        agendaPool.Add(0);
        incidentPool.Add(0);
    }

    public void LoadAgendaIncidentList(int[] agendaList, int[] incidentList)
    {
        if(agendaList == null)
        {
            Init_List_Pool();
        }
        else
        {
            this.agendaList = agendaList;
            this.incidentList = incidentList;
            AgendaPoolSetup();
            IncidentPoolSetup();
        }
    }

    public int[] SaveAgendaList()
    {
        return agendaList;
    }

    public int[] SaveIncidentList()
    {
        return incidentList;
    }

    public IEnumerator DelayedStatusChange(short incidentOrAgenda, int eventNum, int responseNum, float time)
    {
        yield return new WaitForSeconds(time);

        int[] type = new int[4] { 0, 1, 2, 3 };
        float[] value = new float[4];
        if (incidentOrAgenda == 0) 
            for(int i = 0; i < 4; i++)
                value[i] = incidentData.statusChange[eventNum, responseNum, i];
        else
            for (int i = 0; i < 4; i++)
                value[i] = agendaData.statusChange[eventNum, responseNum, i];
        statusManager.ChangeStatus(type, value);
    }
}
