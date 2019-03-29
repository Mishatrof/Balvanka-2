using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsControll : MonoBehaviour
{
   

                                                                                  //---------------------------------------//
                                                                                 //    СКРИПТ ОТВЕЧАЮЩИЙ ЗА АСТЕРОИДОВ    //
                                                                                //---------------------------------------//

    [Header("Скорость")]
   public float Speed = 0.7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += new Vector3(0f, -Speed * Time.deltaTime, 0f);
        transform.Rotate(Vector3.forward, 25 * Time.deltaTime);
    }
}
