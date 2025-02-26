using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Warp")]
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed = 1f;

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    protected virtual void Warping()
    {
        if (this.isWarping) return;
        if (this.IsDirectionNotSet()) return;

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }

    protected virtual void WarpFinish()
    {
        this.warpDirection.Set(0f, 0f, 0f, 0f);
        this.isWarping = false;
        Active();
    }

    protected virtual bool IsDirectionNotSet()
    {
        return this.warpDirection.x == 0 && this.warpDirection.y == 0 && this.warpDirection.z == 0 && this.warpDirection.w == 0;
    }

    protected virtual void CheckWarpDirection()
    {
        if (!this.isReady) return;
        if (this.isWarping) return;

        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();
    }

    protected virtual void WarpLeft()
    {
        this.warpDirection.x = 1;
    }

    protected virtual void WarpRight()
    {
        this.warpDirection.y = 1;
    }

    protected virtual void WarpUp()
    {
        this.warpDirection.z = 1;
    }

    protected virtual void WarpDown()
    {
        this.warpDirection.w = 1;
    }
}
