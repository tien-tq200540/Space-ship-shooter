using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDistance : ObjShooting
{
    [Header("Shoot By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(this.transform.position, this.target.position);
        this.isShooting = this.distance < this.shootDistance;
        return this.isShooting;
    }
}
