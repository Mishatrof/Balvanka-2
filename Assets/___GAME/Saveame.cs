using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saveame : MonoBehaviour
{
    public GameObject[] obj;
  
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SAVEGAME()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            string id = obj[i].GetInstanceID().ToString();
            Vector3 pos = obj[i].transform.position;
            PlayerPrefs.SetFloat(id + "PLAYER_POS_X", pos.x);
            PlayerPrefs.SetFloat(id + "PLAYER_POS_Y", pos.y);
            PlayerPrefs.SetFloat(id + "PLAYER_POS_Z", pos.z);
        }
        PlayerPrefs.Save();
        Debug.Log("12");
    }
    public void StartGame()
    {

        if (PlayerPrefs.HasKey( "PLAYER_POS_X"))
        {

            for (int i = 0; i < obj.Length; i++)
            {
                string id = obj[i].GetInstanceID().ToString();

                float pos_x = PlayerPrefs.GetFloat(id + "PLAYER_POS_X");
                float pos_y = PlayerPrefs.GetFloat(id + "PLAYER_POS_Y");
                float pos_z = PlayerPrefs.GetFloat(id + "PLAYER_POS_Z");
                Vector3 pos = new Vector3(pos_x, pos_y, pos_z);
                obj[i].transform.position = pos;
            }

            Debug.Log("1");
        }
        Debug.Log("cant");
    
}
}
