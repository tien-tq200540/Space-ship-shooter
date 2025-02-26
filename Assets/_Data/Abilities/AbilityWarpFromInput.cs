using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarpFromInput : AbilityWarp
{
    //[Header("From Input")]

    protected override void Update()
    {
        base.Update();
        this.UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection()
    {
        this.keyDirection = InputManager.Instance.Direction;
    }
}
