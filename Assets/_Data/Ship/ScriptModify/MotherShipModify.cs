using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjModifyAbstract
{
    [Header("Mother Ship")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.1f;
    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootableObjectCtrl.ObjMovement.SetSpeed(speed);
        this.shootableObjectCtrl.ObjLookAtTarget.SetRotSpeed(rotSpeed);
    }
}
