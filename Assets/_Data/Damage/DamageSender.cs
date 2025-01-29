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
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
    }
}
