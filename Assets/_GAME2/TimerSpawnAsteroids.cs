using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawnAsteroids : MonoBehaviour
{

                                                                                  //---------------------------------------//
                                                                                 //   СКРИПТ ОТВЕЧАЮЩИЙ ЗА ПУЛ АСТЕРОИДОВ //
                                                                                //---------------------------------------//
    [Header("Место спавна Астероидов")]
    public Transform[] SpawnTransform;
    [Header("Место Пула")]
    public Transform PoolASteroids;

    float fireTime = 3f;
    float Timer = 3f;
    int numberChild = 0;

    private void Start()
    {
        PoolASteroids = GameObject.Find("POOL_ASTEROIDS").transform;
    }

    private void FixedUpdate()
    {
        
            Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
           GameObject  bullRB = PoolASteroids.GetChild(numberChild).gameObject;
            bullRB.gameObject.SetActive(true);
            bullRB.transform.position = SpawnTransform[Random.Range(0, 3)].position;
           
            numberChild++;

            if (numberChild >= PoolASteroids.childCount)
                numberChild = 0;
            Timer = Random.Range(1,3f);
        }
    }
}
