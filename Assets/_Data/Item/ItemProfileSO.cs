using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public Sprite sprite;
    public List<ItemRecipe> upgradeLevels = new();

    public static ItemProfileSO GetItemProfileByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles.Cast<ItemProfileSO>())
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
}
