using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : TienMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.Log($"{transform.name}: LoadSpawner", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.Log($"{transform.name}: LoadFollowTarget", gameObject);
    }

    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = GetComponentInChildren<SliderHP>();
        Debug.Log($"{transform.name}: LoadSliderHP", gameObject);
    }

    public virtual void SetShootableObjCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;

        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            spawner.Despawn(transform);
            return;
        }

        float maxHP = this.shootableObjectCtrl.DamageReceiver.HPMax;
        float curHP = this.shootableObjectCtrl.DamageReceiver.HP;
        this.sliderHP.SetMaxHP(maxHP);
        this.sliderHP.SetCurrentHP(curHP);
    }
}
