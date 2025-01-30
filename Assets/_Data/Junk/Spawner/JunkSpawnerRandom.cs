using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : TienMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log($"{transform.name}: LoadJunkCtrl", gameObject);
    }

    private void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        if (this.randomTimer < this.randomDelay)
        {
            this.randomTimer += Time.fixedDeltaTime;
            return;
        }
        this.randomTimer = 0f;

        Vector3 pos = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom().position;
        Quaternion rot = transform.rotation;
        Transform obj = junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

       //Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        return this.junkSpawnerCtrl.JunkSpawner.SpawnedCount >= this.randomLimit;
    }
}
