using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectAbstract : TienMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log($"{transform.name}: LoadShootableObjectCtrl", gameObject);
    }
}
