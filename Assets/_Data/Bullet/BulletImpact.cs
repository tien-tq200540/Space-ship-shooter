using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadRigidBody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponentInChildren<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log($"{transform.name}: LoadCollider", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponentInChildren<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log($"{transform.name}: LoadRigidBody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.DamageSender.Send(other.transform);
    }
}
