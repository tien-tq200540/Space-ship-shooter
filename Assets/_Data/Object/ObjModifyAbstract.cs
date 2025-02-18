using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjModifyAbstract : TienMonoBehaviour
{
    [Header("Modify")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = GetComponent<ShootableObjectCtrl>();
        Debug.Log($"{transform.name}: LoadShootableObjectCtrl", gameObject);
    }
}
