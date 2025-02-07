using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 10);
    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
        Debug.Log("Upgrade call!");
    }

    public virtual bool UpgradeItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= this.inventory.Items.Count) return false; //Check if index is satisfied
        //Check if index slot has a item
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        if (itemInventory == null) return false;

        if (!IsItemUpgradeable(itemInventory, itemInventory.level)) return false;
        if (!HasEnoughIngredients(itemInventory, itemInventory.level)) return false;
        DeductIngredients(itemInventory, itemInventory.level);
        itemInventory.level++;
        return true;
    }

    protected virtual bool IsItemUpgradeable(ItemInventory itemInventory, int currentLevel)
    {
        //Check if item has a recipe to upgrade
        if (itemInventory.itemProfile.upgradeLevels.Count < 1) return false;
        if (itemInventory.itemProfile.upgradeLevels.Count <= currentLevel) return false;
        return true;
    }

    protected virtual bool HasEnoughIngredients(ItemInventory itemInventory, int currentLevel)
    {
        ItemRecipe itemUpgradeRecipe = itemInventory.itemProfile.upgradeLevels[currentLevel];
        foreach (var ingredient in itemUpgradeRecipe.ingredients)
        {
            ItemCode itemCode = ingredient.item.itemCode;
            int totalItem = GetTotalItem(itemCode);
            if (totalItem < ingredient.count) return false;  
        }
        return true;
    }

    protected virtual int GetTotalItem(ItemCode itemCode)
    {
        int total = 0;
        foreach (var item in this.inventory.Items)
        {
            if (item.itemProfile.itemCode != itemCode) continue;
            total += item.itemCount;
        }
        return total;
    }

    protected virtual void DeductIngredients(ItemInventory itemInventory, int currentLevel)
    {
        ItemRecipe itemUpgradeRecipe = itemInventory.itemProfile.upgradeLevels[currentLevel];
        foreach (var ingredient in itemUpgradeRecipe.ingredients)
        {
            ItemCode itemCode = ingredient.item.itemCode;
            this.inventory.DeductItem(itemCode, ingredient.count);
        }
    }
}
