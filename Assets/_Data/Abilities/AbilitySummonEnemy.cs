using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions = new();
    [SerializeField] protected int minionLimit = 4;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
        Debug.Log($"{transform.name}: LoadSpawner", gameObject);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearDeathMinion();
    }

    protected override void Summoning()
    {
        if (this.minions.Count >= minionLimit) return;
        base.Summoning();
    }

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion; 
    }

    protected virtual void ClearDeathMinion()
    {
        foreach (Transform minion in this.minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}
