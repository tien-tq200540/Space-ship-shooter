using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TienMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<DamageSender>();
        Debug.Log($"{transform.name}: LoadDamageSender", gameObject);
    }
}
