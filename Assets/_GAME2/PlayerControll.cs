using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
                                                                                  //---------------------------------------//
                                                                                 //СКРИПТ ОТВЕЧАЮЩИЙ ЗА УПРАВЛЕНИЕ КОРАБЛЁМ//
                                                                                //---------------------------------------//
                                                                                 
    [Header("Player")]
    GameObject Player;

    [Header("Скорость")]
    float Speed = 2f;

    [Header("Пул патронов")]
    Transform PoolBullet; 

    int numberChild = 0;

    [Header("Место Спавна пули")]
    public Transform pos;

    void Start()
    {
        Player = gameObject;
    }

    
    void Update()
    {
        PlayControll();
        Shoot();
        PoolBullet = GameObject.Find("POOL_BULLET").transform;
    }
                                                                                  //---------------------------------------//
                                                                                 //           УПРАВЛЕНИЕ                  //
                                                                                //---------------------------------------//

    void PlayControll()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -0.9)
                Player.transform.position += new Vector3(-Speed * Time.deltaTime, 0.0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 0.9)
                Player.transform.position += new Vector3(Speed * Time.deltaTime, 0.0f, 0f);
        }
    }
                                                                                  //---------------------------------------//
                                                                                 //             СТРЕЛЬБА                  //
                                                                                //---------------------------------------//

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D bullRB = PoolBullet.GetChild(numberChild).GetComponent<Rigidbody2D>();
            bullRB.gameObject.SetActive(true);
            bullRB.position = pos.position;
            bullRB.velocity = Vector3.zero;
            bullRB.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            numberChild++;

            if (numberChild >= PoolBullet.childCount)
                numberChild = 0;
        }
    }
    

}
