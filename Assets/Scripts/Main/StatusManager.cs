using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] Slider[] statusGage;
    float[] statusValue = new float[4]; //0 : smile, 1 : economy, 2 : corruption, 3 : approval

    private void Start()
    {
        for (int i = 0; i < 4; i++)
            statusValue[i] = 0.5f;

        ChangeStatus(new int[4] { 0, 1, 2, 3 }, new float[4] { 0, 0, 0, 0 });
    }

    public void ChangeStatus(int[] type, float[] value)
    {
        for(int i = 0; i < type.Length; i++)
        {
            statusValue[type[i]] += value[i];
            statusGage[type[i]].value = statusValue[type[i]];
        }
    }

    public float[] GetStatus()
    {
        return statusValue;
    }
}
