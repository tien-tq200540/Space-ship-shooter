using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : TienMonoBehaviour
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;
    public List<ItemDropCount> dropCountItems = new();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Dropping), 2, 0.5f);
    }

    protected virtual void Dropping()
    {
        dropCount++;
        transform.GetPositionAndRotation(out Vector3 dropPos, out Quaternion dropRot);
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);

        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemDropCount item = dropCountItems.Find(i => i.itemName == itemDropRate.itemSO.itemName);
            if (item == null)
            {
                item = new ItemDropCount();
                item.itemName = itemDropRate.itemSO.itemName;
                dropCountItems.Add(item);
            }

            item.count++;
            item.rate = (float)Math.Round((float)item.count/this.dropCount, 2);
        }
    }
}

[System.Serializable]
public class ItemDropCount
{
    //For saving information about item and drop rate for testing
    public string itemName = string.Empty;
    public int count = 0;
    public float rate;
}
