using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : TienMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
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

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        float maxHP = this.shootableObjectCtrl.DamageReceiver.HPMax;
        float curHP = this.shootableObjectCtrl.DamageReceiver.HP;
        this.sliderHP.SetMaxHP(maxHP);
        this.sliderHP.SetCurrentHP(curHP);
    }
}
