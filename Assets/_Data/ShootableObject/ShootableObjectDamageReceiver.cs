using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log($"{transform.name}: LoadCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop(); //Drop item or anything in here
        this.shootableObjectCtrl.Despawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        transform.GetPositionAndRotation(out Vector3 dropPos, out Quaternion dropRot);
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObjectSO.dropList, dropPos, dropRot); //pass the corresponding drop list of junk to the DropManager
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
        this.hpMax = this.shootableObjectCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
