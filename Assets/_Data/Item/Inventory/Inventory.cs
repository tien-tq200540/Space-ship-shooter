using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : TienMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items = new();

    protected override void Start()
    {
        base.Start();
        //for testing
        AddItem(ItemCode.IronOre, 3);
        DeductItem(ItemCode.IronOre, 1);
        DeductItem(ItemCode.GoldOre, 1);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = GetItemByCode(itemCode);

        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    {
        //Find item
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        //If item not in inventory -> false
        if (itemInventory == null) return false;

        int newCount = itemInventory.itemCount - deductCount;
        //if deduct more than item count in inventory -> false
        if (newCount < 0) return false;
        itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles.Cast<ItemProfileSO>())
        {
            if (profile.itemCode != itemCode) continue;

            ItemInventory itemInventory = new()
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack,
            };

            this.items.Add(itemInventory);
            return itemInventory;
        }

        //Cannot find a ItemProfile with same itemCode
        return null;
    }
}
