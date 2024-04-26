using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, IDamagable
{
    public NavMeshAgent agent;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private BaseStats baseStats;
    [SerializeField]
    private List<GameObject> hitTargets;

    public BaseStats Stats
    {
        get { return baseStats; }
        set { baseStats = value; }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    public List<GameObject> HitTargets
    {
        get { return hitTargets; }
    }

    void IDamagable.TakeDamage(float amount)
    {
        baseStats.CurrentHealth -= amount;
    }

    private void Update()
    {
        if(Stats.CurrentHealth > 0)
        {
            agent.speed = Stats.MoveSpeed;
            Stats.UpdateStats();
            if (target != null)
                agent.SetDestination(target.transform.position);
        }
    }
}
