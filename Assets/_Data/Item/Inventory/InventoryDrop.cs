using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 10);
        Invoke(nameof(this.Test2), 30);
    }

    protected virtual void Test()
    {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        DropItemByIndex(0, dropPos, transform.rotation);
    }

    protected virtual void Test2()
    {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        DropItemByIndex(4, dropPos, transform.rotation);
    }

    protected virtual void DropItemByIndex(int itemIndex, Vector3 dropPos, Quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}
