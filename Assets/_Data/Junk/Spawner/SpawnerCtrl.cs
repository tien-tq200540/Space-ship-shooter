using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : TienMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawner();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log($"{transform.name}: LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
        Debug.Log($"{transform.name}: LoadSpawnPoints", gameObject);
    }
}
