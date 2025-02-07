using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstract : TienMonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log($"{transform.name}: LoadInventory", gameObject);
    }
}
