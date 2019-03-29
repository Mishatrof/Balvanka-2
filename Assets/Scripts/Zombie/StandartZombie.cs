using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StandartZombie : MonoBehaviour, Zombie
{

    public enum Condition
    {
        Move,
        Attack
    }
    [Header("Текущее состояние:")]
    public Condition CurrentCondition;
    public Transform PlayerPosition;

    public Transform CurrentTarget;

    private NavMeshAgent agent;

    // Таймер атак
    private ZombieAttackTimer timer;

    public float DistanceTotarget;

    // Игровые параметры
    [Header("Игровые параемтры:")]
    public float health;
    public int damage;
    public float moveSpeed;
    public float attackRadius;
    // Время между ударами
    [Header("Время между ударами")]
    public float attackSpeed;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        // Задаём скорость перемещения
        agent.speed = moveSpeed;

        // * После спавна, зомби сразу идёт по "запаху" игрока *
        CurrentCondition = Condition.Move;

        timer = GetComponent<ZombieAttackTimer>();
        

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, attackRadius);
        Gizmos.color = Color.red;
    }
    void Update()
    {   // test ---
        agent.updateRotation = false;
        FaceTarget();
        // ---

        // Проверка состояния
        switch (CurrentCondition)
        {
            // Вызов метода перемещения
            case Condition.Move:
                MoveToTarget(); break;
            // Вызов метода атаки
            case Condition.Attack:
                AttackTheTarget(); break;
        }
        

    }

    public void MoveToTarget()
    {
        // test
        agent.SetDestination(PlayerPosition.position);
        agent.stoppingDistance = 1.0f;
        DistanceTotarget = Vector3.Distance(gameObject.transform.position, PlayerPosition.position);
        if (DistanceTotarget <= attackRadius)
        {
            CurrentCondition = Condition.Attack;
        }
        // --- 
    }
    public void AttackTheTarget()
    {
        // test
        DistanceTotarget = Vector3.Distance(gameObject.transform.position, PlayerPosition.position);
        if (DistanceTotarget > attackRadius)
        {
            CurrentCondition = Condition.Move;
        }
        if (!timer.isStart)
        {
            Debug.Log("Кусь от "+gameObject.name);
            timer.MaxTime = attackSpeed;
            timer.isStart = true;
        }
    }
         // ---
    public void FaceTarget()
    {
        Vector3 direction = (PlayerPosition.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
