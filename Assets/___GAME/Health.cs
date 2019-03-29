using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public int hp = 6;
    private bool isDie;
    public Sprite[] HeartSP;
    public Image[] hpImage;
    public bool isPlayer;


    public GameObject DIE;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer) {
            switch (hp)
            {
                case 6:
                    hpImage[2].enabled =  true;
                  
                    break;
                case 4:
                    hpImage[1].enabled  = true;
                    hpImage[2].enabled = false;
                 
                    break;
                case 2:
                    hpImage[0].enabled =  true;
                    hpImage[1].enabled = false;
                  
                   
                    break;
                case 0:
                    hpImage[0].enabled = false;
                    Time.timeScale = 0f;
                    DIE.SetActive(true);

                    break;
            }
                 }
        if (isDie)
        {
            Destroy(gameObject);
        }
    }
    public void TakeHP(int dmg)
    {
        hp  += dmg;
        if (hp >= 100)
        {
            hp = 100;
           
        }
    }
    public void TakeDamage(int dmg)
    {
        bool isAttacks =false ;
        isAttacks = true;
        if (isAttacks)
        {
            hp -= dmg;
            isAttacks = false;
        }
        if(hp <= 0)
        {
            hp = 0;
            isDie = true;
        }
    }
}
