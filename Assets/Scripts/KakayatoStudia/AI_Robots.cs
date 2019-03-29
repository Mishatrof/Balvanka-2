using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Robots : MonoBehaviour {

    public enum PeopleType
    {
        Worker,
        Armor,
        Traider
    }
    public PeopleType peopleType;
    public List<GameObject> JobList;

    [Header("Точка пути")]
    public Transform Point;
    [Header("Дистанция до цели")]
    public float Dis;
    [Header("Навигатор")]
    NavMeshAgent nav;
    [Header("Глоблаьное время")]
    public RealTime realTime;
    [Header("Приоритет к цели")]
    public int priority;
    [Header("________________________")]
    [Header("ДЛЯ ГЕЙМ-ДИЗА")]
    public string[] jobs;
    public string currentJob;
    [Header("ДЛЯ ГЕЙМ-ДИЗА(ЦЕЛЬ КУДА ПОПАСТЬ)")]
    public Transform[] targetCell;
    int pointcell;
    
    private bool IsSleep;
    private bool IsWork;

    private void Start()
    {
        pointcell = 0;
        nav = GetComponent<NavMeshAgent>();
        JobList = new List<GameObject>();
    }

    private void Update()
    {
        if (Point == null) return ;
        Prioritet();
        switch (peopleType)
        {
            case PeopleType.Armor:
                ArmorPeople();
                break;
            case PeopleType.Worker:
                WorkerPeople();
                break;
            case PeopleType.Traider:
                TraiderPeople();
                break;

        }
            
        if (peopleType == PeopleType.Worker)
        {
            if (realTime.Hours >= 7 && realTime.Hours <= 8)

                currentJob = "WakeUp";

            if (realTime.Hours >= 8 && realTime.Hours <= 9)
                currentJob = "Eat";
            if (realTime.Hours >= 10 && realTime.Hours <= 15)
                currentJob = "Work";
            if (realTime.Hours >= 15 && realTime.Hours <= 17)
                currentJob = "Eat";
            if (realTime.Hours >= 18 && realTime.Hours <= 21)
                currentJob = "Work";
            if (realTime.Hours >= 21 )
            {
                currentJob = "Sleep";
            }
        }
        if (peopleType == PeopleType.Armor)
        {
            if (realTime.Hours >= 7 && realTime.Hours <= 8)

                currentJob = "WakeUp";

            if (realTime.Hours >= 8 && realTime.Hours <= 9)
                currentJob = "Eat";
            if (realTime.Hours >= 10 && realTime.Hours <= 17)
            {
                currentJob = "Sleep";
            }
        }




    }
    void Prioritet()
    {
        switch (priority)
        {
            case 0:
                //обычная цель
                break;
            case 1:
                //приоритет номер 1
                break;
            case 2:
                //приоритет номер 2
                break;
            case -1:
                //не нужное 
                break;
            case -2:
                // оч не нужное 
                break;
        }

    }
   
    void WorkerPeople()
    {
         
            for (int i = 0; i < jobs.Length; i++)
            {
                
                if (jobs[i].ToString() == currentJob)
                {
                  
                    switch (currentJob)
                    {
                        case "WakeUp":
                        if (IsSleep)
                        {
                            IsSleep = false;
                            nav.enabled = true;
                        }
                        else
                        {
                            Point = targetCell[i];
                            nav.SetDestination(Point.transform.position);
                        }
                        break;
                        case "Eat":
                        if (IsSleep)
                        {
                            IsSleep = false;
                            nav.enabled = true;
                        }
                        if (IsWork)
                        {
                            IsWork = false;
                            nav.enabled = true;
                        }
                        else
                        {
                            Point = targetCell[i];
                            nav.SetDestination(Point.transform.position);
                        }
                        break;

                        case "Go for a walk":
                        if (IsSleep)
                        {
                            IsSleep = false;
                            nav.enabled = true;
                        }
                        else
                        {
                            Point = targetCell[i];
                            nav.SetDestination(Point.transform.position);
                        }
                        break;

                        case "Sleep":
                        if (IsWork)
                        {
                            IsWork = false;
                            nav.enabled = true;
                        }
                        Point = targetCell[i];
                        Dis = Vector3.Distance(transform.position, Point.position);
                        if(Dis > 1.2f && !IsSleep && !IsWork)
                        {
                            nav.SetDestination(Point.transform.position);
                        }
                        else
                        {
                            IsSleep = true;
                            nav.enabled = false;
                            transform.position = Vector3.Slerp(transform.position, Point.position, 3 * Time.deltaTime);
                            transform.rotation = Quaternion.Slerp(transform.rotation, Point.rotation, 3 * Time.deltaTime);
                        }
                        break;
                        case "Work":

                        if (IsSleep)
                        {
                            IsSleep = false;
                            nav.enabled = true;
                        }
                        else
                        {
                            Point = JobList[Random.Range(0, 2)].transform;
                            Dis = Vector3.Distance(transform.position, Point.position);
                            if (Dis > 1.2f && !IsSleep)
                            {
                                nav.SetDestination(Point.transform.position);
                            }
                            else
                            {
                                IsWork = true;
                                nav.enabled = false;
                                transform.position = Vector3.Slerp(transform.position, JobList[0].transform.position, 3 * Time.deltaTime);
                                transform.rotation = Quaternion.Slerp(transform.rotation, JobList[0].transform.rotation, 3 * Time.deltaTime);
                            }
                        }
                            break;
                }

                }
            }
        
    }
    void ArmorPeople()
    {
        for (int i = 0; i < jobs.Length; i++)
        {

            if (jobs[i].ToString() == currentJob)
            {

                switch (currentJob)
                {
                    case "WakeUp":
                        print("WakeUp");
                        Point = targetCell[i];
                        break;
                    case "Eat":
                        print("Eat");
                        Point = targetCell[i];
                        break;
                    case "Go for a Cheld":
                        print("Go for a walk");
                        Point = targetCell[i];
                        break;
                }

            }
        }
    }
    void TraiderPeople()
    {
        for (int i = 0; i < jobs.Length; i++)
        {

            if (jobs[i].ToString() == currentJob)
            {

                switch (currentJob)
                {
                    case "WakeUp":
                        print("WakeUp");
                        Point = targetCell[i];
                        break;
                    case "Eat":
                        print("Eat");
                        Point = targetCell[i];
                        break;
                    case "Go for a Traide":
                        print("Go for a Traide");
                        Point = targetCell[i];
                        break;
                }

            }
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "JobPoint")
        {
            Debug.Log("1");
            JobList.Add(other.transform.gameObject);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "JobPoint")
        {
            Debug.Log("2");
            JobList.Remove(other.transform.gameObject);
        }
    }
}

