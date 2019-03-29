using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTime : MonoBehaviour
{
    public int Day = 0;
    public float Hours = 6;
    public float Minutes = 0;

    private string Chas;
    private string Min;

    
    void Update()
    {
        Minutes += Time.deltaTime * 17;

        Chas = Hours.ToString("0");
        Min = Minutes.ToString("0");
        if(Minutes >= 60f)
        {
            Hours++;
            Minutes = 0f;
        }
        if (Hours >= 24f)
        {
            Hours = 1;
            Day++;
        }
        // Debug.Log("Часы: " + Chas + " Минуты: " + Min);

    }
}
