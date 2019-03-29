using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackTimer : MonoBehaviour
{
    public float MaxTime;
    public bool isStart;

    void Start()
    {
        isStart = false;
    }


    void Update()
    {
        if (isStart && MaxTime > 0)
        {
            MaxTime -= Time.deltaTime;
            if (MaxTime <= 0)
            {
                isStart = false;
            }
        }
    }
}
