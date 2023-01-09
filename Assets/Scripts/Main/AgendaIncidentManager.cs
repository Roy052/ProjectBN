using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgendaIncidentManager : MonoBehaviour
{
    int[] agendaList = new int[5];
    int[] incidentList = new int[5];

    public void LoadAgendaIncidentList(int[] agendaList, int[] incidentList)
    {
        this.agendaList = agendaList;
        this.incidentList = incidentList;
    }

    public int[] SaveAgendaList()
    {
        return agendaList;
    }

    public int[] SaveIncidentList()
    {
        return incidentList;
    }
}
