using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
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
        this.sphereCollider.radius = 0.2f;
        Debug.Log($"{transform.name}: LoadCollider", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return String2ItemCode();
    }

    protected virtual ItemCode String2ItemCode()
    {
        try
        {
            return (ItemCode)Enum.Parse(typeof(ItemCode), transform.parent.name);
        } catch (ArgumentException e)
        {
            Debug.Log(e.Message);
            return ItemCode.NoItem;
        }
    }

    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
        
    }
    protected virtual void OnMouseDown()
    {
        PlayerCtrl.Instance.PlayerPickable.PlayerPicked(this);
    }
}
