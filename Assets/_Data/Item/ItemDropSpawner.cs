using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 DropManager allow to exist!");
        instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 dropPos, Quaternion dropRot)
    {
        if (dropList.Count < 1) return;

        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop =  Spawn(itemCode.ToString(), dropPos, dropRot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 dropPos, Quaternion dropRot)
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
