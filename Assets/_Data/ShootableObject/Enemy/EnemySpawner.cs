using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 EnemySpawner allow to exists!");
        instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBarToObject(newEnemy);
        return newEnemy;
    }

    protected virtual void AddHPBarToObject(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();

        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);

        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetShootableObjCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);
        
        newHpBar.gameObject.SetActive(true);
    }
}
