using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : TienMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log($"{transform.name}: LoadCtrl", gameObject);
    }

    private void FixedUpdate()
    {
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if (this.RandomReachLimit()) return;

        if (this.randomTimer < this.randomDelay)
        {
            this.randomTimer += Time.fixedDeltaTime;
            return;
        }
        this.randomTimer = 0f;

        Vector3 pos = this.spawnerCtrl.SpawnPoints.GetRandomSpawnPoint().position;
        Quaternion rot = transform.rotation;
        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefab();

        Transform obj = spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

       //Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        return this.spawnerCtrl.Spawner.SpawnedCount >= this.randomLimit;
    }
}
