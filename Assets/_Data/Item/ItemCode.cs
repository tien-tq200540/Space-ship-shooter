using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,

    IronOre = 1,
    GoldOre = 2,
    CopperSword = 3,
}

public class ItemParser
{
    public static ItemCode FromString(string stringName)
    {
        bool canConvertToItemCode = Enum.TryParse(typeof(ItemCode), stringName, out var itemCode);
        if (canConvertToItemCode) return (ItemCode)itemCode;
        return ItemCode.NoItem;
    }
}
