using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseAbility : TienMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
     public Abilities Abilities => abilities;

    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.Log($"{transform.name}: LoadAbilities", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Update()
    {
        //For override
    }

    protected virtual void Timing()
    {
        if (this.isReady) return;
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
