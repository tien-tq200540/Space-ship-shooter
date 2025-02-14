using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ShipShooting
{
    protected override bool IsShooting()
    {
        return this.isShooting = InputManager.Instance.OnFiring == 1;
    }
}
