using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHp;

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
    }

    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > maxHp) this.hp = maxHp;
    }

    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
