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
        //When Ship has collider, this line will check if bullet impact with collider of gameObject spawn it
        //- If yes, do noting
        //- Otherwise, send damage
        if (other.transform.parent == this.bulletCtrl.Shooter) return;

        this.bulletCtrl.DamageSender.Send(other.transform);
        this.CreateImpactFX();
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = GetImpactFXName();

        Vector3 hitPos = transform.parent.position;
        Quaternion hitRot = transform.parent.rotation;
        Transform impactFx = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        impactFx.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.impactOne;
    }
}
