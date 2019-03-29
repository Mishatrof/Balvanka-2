using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombie;
    public Transform[] SpawnPos;
    public RealTime realtime;
    public GameObject cam;
    public bool isSpawned;
   


    void Awake()
    {
    
        realtime = GetComponent<RealTime>();
    }

    void Update()
    {
        if (realtime.Day % 2 == 0)
        {
            isSpawned = true;
            Debug.Log("Не подходящий день для Зомби");

        }
        else
        {
            //  WaveManager.StartWaves();
            // Если день подходящий и на сцене есть менеджер волн
            if ((isSpawned == true))
            {
                  SpawnZombies();
               
            }


        }
    }
    public void SpawnZombies()
    {
        for (int i = 0; i < SpawnPos.Length; i++)
        {
            Instantiate(zombie, SpawnPos[i].transform.position, SpawnPos[i].transform.rotation);
        }
        isSpawned = false;


    }

}
