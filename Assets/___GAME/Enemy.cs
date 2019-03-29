using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    Transform Target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(Target.position, transform.position);
        if(dis <= 30f)
        {
            agent.SetDestination(Target.position);

            if(dis <= agent.stoppingDistance)
            {
                Target.GetComponent<Health>().TakeDamage(1);
            }
        }
    }
}
