using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Bu : MonoBehaviour
{
    public GameObject[] Obj;
    
   public FPSController fps;
    public GameObject Pan;
    public GameObject Pan2;



    [Header("Настройки")]
    public Camera cam;                  // Камера игрока
    public Material BuildMaterial;      // Материал который будет наносится при установки объекта
    [Header("Объект который будет создаваться")]
    public GameObject ObjectItem;       // Объект который будет устанавливатся


    private GameObject StartObject;     // Это ссылка на объект который мы пытаемся установить
    private Material StartMaterial;     // Это ссылка на материал объекта
    private float heightObject;         // Высота объекта
    private bool building;          // Высота объекта
    public GameObject Pistoles;          

    public void Pistol()
    {
        fps.SecondWeapon = Pistoles;
    }
    public void OnBuild(int index)
    {
        switch (index)
        {
            case 0:
                fps.GetComponent<FPSController>().Wood -= 5;
                Pan.SetActive(false);
                GameObject go = Obj[0];
                ObjectItem = go;
                Time.timeScale = 1;
                break;
            case 1:
                fps.GetComponent<FPSController>().Wood -= 5;
                Pan.SetActive(false);
                GameObject go1 = Obj[1];
              ObjectItem =  go1 ;
                Time.timeScale = 1;
                break;
            case 2:
                fps.GetComponent<FPSController>().Wood -= 5;
                Pan.SetActive(false);
                GameObject go2 = Obj[2];
                ObjectItem = go2;
                Time.timeScale = 1;
                break;
            case 3:
                fps.GetComponent<FPSController>().Wood -= 5;
                Pan.SetActive(false);
                GameObject go3 = Obj[3];
                ObjectItem = go3;
                Time.timeScale = 1;
                break;
        }
    }

    public void Create()
    {
        if (StartObject.GetComponent<MeshRenderer>())
        {
            StartObject.GetComponent<MeshRenderer>().material = StartMaterial;
        }
        if (StartObject.GetComponent<Rigidbody>())
        {
            StartObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (StartObject.GetComponent<BoxCollider>())
        {
            StartObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (StartObject.GetComponent<SphereCollider>())
        {
            StartObject.GetComponent<SphereCollider>().enabled = true;
        }
        if (StartObject.GetComponent<MeshCollider>())
        {
            StartObject.GetComponent<MeshCollider>().enabled = true;
        }
        if (StartObject.GetComponent<CapsuleCollider>())
        {
            StartObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        ObjectItem = null;
        StartObject = null;
        heightObject = 0;
        Pan2.SetActive(false);
        building = false;
    }

    public void Left()
    {
        StartObject.transform.Rotate(new Vector3(0, 15, 0));
    }
    public void Right()
    {
        StartObject.transform.Rotate(new Vector3(0, -15, 0));
    }
    public void Update()
    {
      
    
        if ( ObjectItem != null)
        {
            building = true;
        }

        if (building == true && ObjectItem != null)
        {
            Pan2.SetActive(true);
             RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 15))
            {
                if (StartObject == null)
                {
                    StartObject = (GameObject)Instantiate(ObjectItem, Vector3.zero, Quaternion.identity);
                    Debug.Log("1");
                    if (StartObject.GetComponent<MeshRenderer>())
                    {
                        StartMaterial = StartObject.GetComponent<MeshRenderer>().material;
                        StartObject.GetComponent<MeshRenderer>().material = BuildMaterial;
                    }
                    if (StartObject.GetComponent<Rigidbody>())
                    {
                        StartObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                    if (StartObject.GetComponent<BoxCollider>())
                    {
                        StartObject.GetComponent<BoxCollider>().enabled = false;
                    }
                    if (StartObject.GetComponent<SphereCollider>())
                    {
                        StartObject.GetComponent<SphereCollider>().enabled = false;
                    }
                    if (StartObject.GetComponent<MeshCollider>())
                    {
                        StartObject.GetComponent<MeshCollider>().enabled = false;
                    }
                    if (StartObject.GetComponent<CapsuleCollider>())
                    {
                        StartObject.GetComponent<CapsuleCollider>().enabled = false;
                    }
                }
                else
                {
                    heightObject = StartObject.transform.lossyScale.y / 2 + hit.point.y;
                    StartObject.transform.position = new Vector3(hit.point.x, heightObject, hit.point.z);
                 
                    
                }
            }
        }
    
}
}
