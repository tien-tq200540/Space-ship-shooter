using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : TienMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable => itemPickupable;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
        LoadItemPickupable();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.Log($"{transform.name}: ItemDespawn", gameObject);
    }

    protected virtual void LoadItemPickupable()
    {
        if (this.itemPickupable != null) return;
        this.itemPickupable = GetComponentInChildren<ItemPickupable>();
        Debug.Log($"{transform.name}: LoadItemPickupable", gameObject);
    }
}
