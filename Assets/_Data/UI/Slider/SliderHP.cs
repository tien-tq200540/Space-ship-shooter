using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 70f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP/this.maxHP;
        this.slider.value = hpPercent;
    }

    protected override void OnChanged(float newValue)
    {
        //Debug.Log($"NewValue = {newValue}");
    }

    protected virtual void SetMaxHP(float value)
    {
        this.maxHP = value;
    }

    protected virtual void SetCurrentHP(float value)
    {
        this.currentHP = value;
    }
}
