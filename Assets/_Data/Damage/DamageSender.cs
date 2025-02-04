using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : TienMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    //Send damage to an Object
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.parent.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = GetImpactFXName();

        Vector3 hitPos = transform.parent.position;
        Quaternion hitRot = transform.parent.rotation;
        Transform impactFx = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        impactFx.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.impactOne;
    }
}
