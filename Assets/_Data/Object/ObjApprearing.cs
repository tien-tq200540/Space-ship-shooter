using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjApprearing : TienMonoBehaviour
{
    [Header("Obj Apprearing")]
    [SerializeField] protected bool isAppearing = true;
    [SerializeField] protected bool appear = false;
    public bool IsApprearing => isAppearing;
    public bool Appear => appear;

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    protected virtual void ObjAppear()
    {
        this.appear = true;
        this.isAppearing = false;
    }
}
