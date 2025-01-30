using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }

        Debug.Log($"{transform.name}: LoadPrefabs", gameObject);
        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log($"{transform.name}: LoadHolder", gameObject);
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning($"Prefab not found: {prefabName}");
            return null;
        }

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = holder;
        this.spawnedCount++;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
}
