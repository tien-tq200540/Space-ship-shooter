using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 10);
    }

    protected virtual void Test()
    {
        DropItem(0);
    }


    protected virtual void DropItem(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
    }

}
