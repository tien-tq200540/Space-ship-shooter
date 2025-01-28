using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : TienMonoBehaviour
{
    [SerializeField] protected float damage = 1f;

    //Send damage to an Object
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.parent.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
