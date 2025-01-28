using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : TienMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log($"{transform.name}: LoadBulletCtrl", gameObject);
    }
}
