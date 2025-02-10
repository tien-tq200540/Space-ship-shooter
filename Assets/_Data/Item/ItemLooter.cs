using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : TienMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadRigidbody();
        LoadInventory();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.25f;
        Debug.Log($"{transform.name}: LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        this._rigidbody.useGravity = false;
        Debug.Log($"{transform.name}: LoadRigidbody", gameObject);
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInParent<Inventory>();
        Debug.Log($"{transform.name}: LoadInventory", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<ItemPickupable>(out var itemPickupable)) return;

        //Add item to inventory
        ItemInventory itemInventory = itemPickupable.ItemCtrl.CurItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            //noti for itemPickupable that we pick this item, so despawn it
            itemPickupable.Picked();
        }
    }
}
