using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : TienMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable => itemPickupable;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
        LoadItemPickupable();
        LoadItemInventory();
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

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.GetItemProfileByItemCode(itemCode);
        itemInventory.itemProfile = itemProfile;
        itemInventory.itemCount = 1;
        Debug.Log($"{transform.name}: LoadItemInventory", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;    
    }
}
