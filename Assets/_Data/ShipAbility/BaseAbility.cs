using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseAbility : TienMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Timing()
    {
        if (isReady) return;
        timer += Time.fixedDeltaTime;
        if (timer < delay) return;
        isReady = true;
    }

    //When active skill, call this to set these variable to base state for next active skill
    protected virtual void Active()
    {
        this.isReady = false;
        this.timer = 0f;
    }
}
