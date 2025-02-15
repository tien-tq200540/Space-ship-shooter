using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
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
}
