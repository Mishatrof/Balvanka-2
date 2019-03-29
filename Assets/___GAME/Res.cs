using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Res : MonoBehaviour
{

    public int Wood;
    public int Stone;
    public Text  Woodt;
    public Text Stonet;

    // Start is called before the first frame update
    void Start()
    {
        Woodt.text = Wood.ToString() ;
        Stonet.text = Stone.ToString() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
