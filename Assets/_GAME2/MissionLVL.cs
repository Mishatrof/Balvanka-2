using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionLVL : MonoBehaviour
{
    public int COUNT = 0;
    public int INDEX;
    public int ZADANOE_CHISLO = 5;
    public GameObject WIN;
    HELPER helper;

    public Text textCpunt;
    public Text textEnd;
    public void Start()
    {
        helper = GameObject.Find("HELPER").GetComponent<HELPER>();
        
        textEnd.text = ZADANOE_CHISLO.ToString();
    }
    private void Update()
    {
        textCpunt.text = COUNT.ToString() + " / ";
        if(COUNT >= ZADANOE_CHISLO)
        {
            switch (INDEX)
            {
                case 0:
                    helper.LVL2 = true;
                    PlayerPrefs.SetInt("LVL2", boolToInt(helper.LVL2));
                    break;
                case 1:
                    helper.LVL3 = true;
                    PlayerPrefs.SetInt("LVL3", boolToInt(helper.LVL3));
                    Debug.Log("1");
                    break;
                case 2:
                    helper.LVL4 = true;
                    PlayerPrefs.SetInt("LVL4", boolToInt(helper.LVL4));
                    break;
                case 3:
                    helper.LVL5 = true;
                    PlayerPrefs.SetInt("LVL5", boolToInt(helper.LVL5));
                    break;
              
            }
            Debug.Log("WIN!");
            WIN.SetActive(true);
        } 
    }
    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
