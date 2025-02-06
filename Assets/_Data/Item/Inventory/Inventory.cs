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
        AddItem(ItemCode.IronOre, 21);
        AddItem(ItemCode.CopperSword, 3);
    }

    public virtual bool AddItem(ItemCode itemCode , int addCount)
    {
        int newCount;
        int remainCount = addCount;
        int itemMaxStack;
        ItemInventory itemExist;
        while (remainCount > 0)
        {
            itemExist = GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;
                itemExist = CreateEmptyItem(itemCode);
                this.items.Add(itemExist);
            }

            itemMaxStack = this.GetItemMaxStack(itemExist);
            newCount = itemExist.itemCount + remainCount;
            if (newCount > itemMaxStack)
            {
                remainCount -= (itemMaxStack - itemExist.itemCount);
                newCount = itemMaxStack;
            } else remainCount = 0;
            itemExist.itemCount = newCount;
        }
        return true;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory item in this.items)
        {
            if (item.itemProfile.itemCode != itemCode) continue;
            if (IsFullStack(item)) continue;
            return item;
        }
        return null;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles.Cast<ItemProfileSO>())
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new()
            {
                itemProfile = profile,
                itemCount = 0,
                maxStack = profile.defaultMaxStack,
            };
            return itemInventory;
        }
        return null;
    }

    protected virtual bool IsFullStack(ItemInventory item)
    {
        return item.itemCount >= item.maxStack;
    }

    protected virtual bool IsInventoryFull()
    {
        return this.items.Count >= this.maxSlot;
    }

    protected virtual int GetItemMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    //public virtual bool AddItem(ItemCode itemCode, int addCount)
    //{
    //    ItemInventory itemInventory = GetItemByCode(itemCode);

    //    int newCount = itemInventory.itemCount + addCount;
    //    if (newCount > itemInventory.maxStack) return false;

    //    itemInventory.itemCount = newCount;
    //    return true;
    //}

    //public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    //{
    //    //Find item
    //    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    //    //If item not in inventory -> false
    //    if (itemInventory == null) return false;

    //    int newCount = itemInventory.itemCount - deductCount;
    //    //if deduct more than item count in inventory -> false
    //    if (newCount < 0) return false;
    //    itemInventory.itemCount = newCount;
    //    return true;
    //}

    //protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    //{
    //    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    //    if (itemInventory == null) itemInventory = AddEmptyProfile(itemCode);
    //    return itemInventory;
    //}

    //protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    //{
    //    var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
    //    foreach (ItemProfileSO profile in profiles.Cast<ItemProfileSO>())
    //    {
    //        if (profile.itemCode != itemCode) continue;

    //        ItemInventory itemInventory = new()
    //        {
    //            itemProfile = profile,
    //            maxStack = profile.defaultMaxStack,
    //        };

    //        this.items.Add(itemInventory);
    //        return itemInventory;
    //    }

    //    //Cannot find a ItemProfile with same itemCode
    //    return null;
    //}
}
