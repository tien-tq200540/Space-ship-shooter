using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : TienMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log($"{transform.name}: LoadCollider", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return String2ItemCode();
    }

    protected virtual ItemCode String2ItemCode()
    {
        return (ItemCode)Enum.Parse(typeof(ItemCode), transform.parent.name);
    }

    public virtual void Picked()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
