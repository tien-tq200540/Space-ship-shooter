using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        foreach (Transform spawnPoint in transform)
        {
            this.spawnPoints.Add(spawnPoint);
        }
        Debug.Log($"{transform.name}: LoadSpawnPoints", gameObject);
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, spawnPoints.Count);
        return this.spawnPoints[rand];
    }
}
