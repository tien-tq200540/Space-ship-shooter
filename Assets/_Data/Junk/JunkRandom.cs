using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : TienMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log($"{transform.name}: LoadJunkCtrl", gameObject);
    }

    private void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = this.junkCtrl.JunkSpawnPoints.GetRandom().position;
        Quaternion rot = transform.rotation;
        Transform obj = junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
