using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TienMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => this.shooter; set => this.shooter = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageSender();
        LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<DamageSender>();
        Debug.Log($"{transform.name}: LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.Find("Despawn").GetComponent<BulletDespawn>();
        Debug.Log($"{transform.name}: LoadBulletDespawn", gameObject);
    }
}
