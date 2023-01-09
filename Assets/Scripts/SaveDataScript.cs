using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public float[] status;

    public int logLength;
    public int[] logData;

    public int[] agendaList;
    public int[] incidentList;


    public SaveData()
    {
        status = new float[4] { 0.5f, 0.5f, 0.5f, 0.5f };
        logLength = 0;
        logData = new int[400];

        agendaList = new int[5];
        incidentList = new int[5];
    }

    public SaveData(SaveData saveData)
    {
        this.status = saveData.status;
        this.logLength = saveData.logLength;
        this.logData = saveData.logData;
        this.agendaList = saveData.agendaList;
        this.incidentList = saveData.incidentList;
    }

    public SaveData(float[] status, int logLength, int[] logData, int[] agendaList, int[] incidentList)
    {
        this.status = status;
        this.logLength = logLength;
        this.logData = logData;
        this.agendaList = agendaList;
        this.incidentList = incidentList;
    }
}
public class SaveDataScript
{
    static public void CreateSaveData()
    {
        SaveData saveData = new SaveData();
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.pbn", save);
    }

    static public void SaveIntoJson(SaveData copyData)
    {
        SaveData saveData = new SaveData(copyData);
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.pbn", save);
    }

    static public void SaveIntoJson(float[] status, int logLength, int[] logData, int[] agendaList, int[] incidentList)
    {
        SaveData saveData = new SaveData(status, logLength,logData, agendaList, incidentList);
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.pbn", save);
    }

    static public SaveData LoadFromJson()
    {
        try
        {
            string path = "./Assets/Save/SaveData.pbn";
            //Debug.Log(path);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                //Debug.Log(json);
                SaveData sd = JsonUtility.FromJson<SaveData>(json);
                return sd;
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
        return default;
    }

    static public void DeleteSave()
    {
        try
        {
            string path = "./Assets/Save/SaveData.pbn";
            //Debug.Log(path);
            if (File.Exists(path))
            {
                File.Delete(path);
                SaveDataScript.RefreshEditor();
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }
    static public void RefreshEditor()
    {
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }
}
