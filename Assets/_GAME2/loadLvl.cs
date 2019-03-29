using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadLvl : MonoBehaviour
{
    HELPER helper;
    private void Start()
    {
        helper = GameObject.Find("HELPER").GetComponent<HELPER>();
    }
    public void Load(int lvl)
    {
        switch (lvl)
        {
            case 0:
                if (helper.LVL1)
                    Application.LoadLevel(lvl);
                break;
            case 1:
                if (helper.LVL2)
                    Application.LoadLevel(lvl);
                break;
            case 2:
                if (helper.LVL3)
                    Application.LoadLevel(lvl);
                break;
            case 3:
                if (helper.LVL4)
                    Application.LoadLevel(lvl);
                break;
            case 4:
                if (helper.LVL5)
                    Application.LoadLevel(lvl);
                break;
            default:
                                    Application.LoadLevel(lvl);
                break;
        }
        
        Time.timeScale = 1f;
    }
}
