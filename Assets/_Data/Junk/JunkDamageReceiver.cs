using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log($"{transform.name}: LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
        this.OnDeadFX();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.parent.position, Quaternion.identity);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }

    protected override void Reborn()
    {
        this.maxHp = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
