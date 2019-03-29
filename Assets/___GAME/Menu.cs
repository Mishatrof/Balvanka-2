using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject Fon;
    public GameObject Game;

   
    public GameObject Rzrab;

    public GameObject Pause;
    public GameObject Inventory;

    public GameObject dd;

    public void OnPlay()
    {
        GamePanel.SetActive(true);
        Game.SetActive(false);
       
    }
    public void OnStartGame()
    {
        Fon.SetActive(true);
        dd.GetComponent<Saveame>().StartGame();
        Application.LoadLevel(1);
      
    }
    public void OnExitGame()
    {
     //   dd.GetComponent<Saveame>().SAVEGAME();
        Application.Quit();

    }
    public void OnBack()
    {
        Rzrab.SetActive(false);

    }
    public void Razrab()
    {
        Rzrab.SetActive(true);
     

    }
    public void pause()
    {
        Pause.SetActive(true);

        Time.timeScale = 0;
    }
    public void ProdoljitGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);


    }
    public void Inv()
    {
        Time.timeScale = 0;
        Inventory.SetActive(true);


    }
    public void InvExit()
    {
        Time.timeScale = 1;
        Inventory.SetActive(false);


    }
}
