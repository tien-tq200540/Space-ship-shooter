using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : TienMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.Log($"{transform.name}: LoadInventory", gameObject);
    }
}
