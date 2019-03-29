using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HELPER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
  
    public Text Lvl2Text;
    public Text Lvl3Text;
    public Text Lvl4Text;
    public Text Lvl5Text;

    public bool LVL1;
    public bool LVL2;
    public bool LVL3;
    public bool LVL4;
    public bool LVL5;

 
   
    private void Awake()
    {
      //  PlayerPrefs.DeleteAll();
            GameObject[] objs = GameObject.FindGameObjectsWithTag("HELPER");
            if (objs.Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        

        if (PlayerPrefs.HasKey("LVL2"))
        {
            LVL2 = intToBool(PlayerPrefs.GetInt("LVL2", 0));
            Lvl2Text.text = "ОТКРЫТ";
        }
        if (PlayerPrefs.HasKey("LVL3"))
        {
            LVL3 = intToBool(PlayerPrefs.GetInt("LVL3", 0));
            Lvl3Text.text = "ОТКРЫТ";
            Lvl2Text.text = "ВЫПОЛНЕН";
        }
        if (PlayerPrefs.HasKey("LVL4"))
        {
            LVL4 = intToBool(PlayerPrefs.GetInt("LVL4", 0));
            Lvl4Text.text = "ОТКРЫТ";
            Lvl3Text.text = "ВЫПОЛНЕН";
        }
        if (PlayerPrefs.HasKey("LVL5"))
        {
            LVL5 = intToBool(PlayerPrefs.GetInt("LVL5", 0));
            Lvl5Text.text = "ОТКРЫТ";
            Lvl4Text.text = "ВЫПОЛНЕН";
        }


      
    }
    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
