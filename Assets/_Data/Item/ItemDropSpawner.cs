using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [SerializeField] protected float gameDropRate = 1f;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 DropManager allow to exist!");
        instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 dropPos, Quaternion dropRot)
    {
        List<ItemDropRate> dropItems = new();
        if (dropList.Count < 1) return dropItems;

        dropItems = this.DropItems(dropList);

        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            Transform itemDrop = Spawn(itemCode.ToString(), dropPos, dropRot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItems;
    }

    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new();

        float rate, itemRate;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate * this.gameDropRate;

            if (rate <= itemRate)
            {
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 dropPos, Quaternion dropRot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = Spawn(itemCode.ToString(), dropPos, dropRot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }
}
