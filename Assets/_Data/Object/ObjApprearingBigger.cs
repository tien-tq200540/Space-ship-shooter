using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjApprearingBigger : ObjApprearing
{
    [Header("Obj Apprearing Bigger")]
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected float speedScale = 0.01f;

    protected override void OnEnable()
    {
        base.OnEnable();
        InitScale();    
    }

    protected virtual void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
        this.isAppearing = true;
        this.appear = false;
    }

    protected override void Appearing()
    {
        if (!this.isAppearing) return;
        this.currentScale += this.speedScale;
        transform.parent.localScale = new Vector3(1f, 1f, 1f) * this.currentScale;
        if (this.currentScale >= this.maxScale) ObjAppear();
    }

    protected override void ObjAppear()
    {
        this.currentScale = this.maxScale;
        transform.parent.localScale = new Vector3(1f, 1f, 1f) * this.maxScale;
        base.ObjAppear();
    }
}
