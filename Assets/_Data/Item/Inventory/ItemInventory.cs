using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public string itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int level = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory();
        itemId = RandomId();
        item.itemProfile = this.itemProfile;
        item.itemCount = this.itemCount;
        item.level = this.level;
        return item;
    }

    public static string RandomId()
    {
        return RandomStringGenerator.Generate(27);
    }
}
