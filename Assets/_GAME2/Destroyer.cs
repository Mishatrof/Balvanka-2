using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
                                                                                  //---------------------------------------//
                                                                                 //СКРИПТ ОТВЕЧАЮЩИЙ ЗА УНИЧТОЖЕНИЕ ОБЪЕКТОВ//
                                                                                //---------------------------------------//



        GameObject mission; // MISSION LVL

  
    private void Start()
    {
        mission = GameObject.Find("Main Camera").GetComponent<MissionLVL>().gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
      
        if(collision.tag == "DEATH")// зоны смерти пуль и астероидов
        {
          
            gameObject.SetActive(false);
        }
        if (collision.tag == "ASTEROIDS")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            mission.GetComponent<MissionLVL>().COUNT++;
        }
        if (collision.tag == "Player")
        {

            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            gameObject.SetActive(false);
        }
    }
}
