using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 3);
        Invoke(nameof(this.Test), 5);
        Invoke(nameof(this.Test), 7);
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

        //Get the recipe of this level
        if (!IsItemUpgradeable(itemInventory, itemInventory.level)) return false;
        List<ItemRecipeIngredient> itemRecipeIngredients = itemInventory.itemProfile.upgradeLevels[itemInventory.level].ingredients;
        if (!HasEnoughIngredients(itemRecipeIngredients)) return false;
        DeductIngredients(itemRecipeIngredients);
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

    protected virtual bool HasEnoughIngredients(List<ItemRecipeIngredient> itemRecipeIngredients)
    {
        foreach (var ingredient in itemRecipeIngredients)
        {
            ItemCode itemCode = ingredient.item.itemCode;
            int totalItem = this.inventory.GetTotalItem(itemCode);
            if (totalItem < ingredient.count) return false;  
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipeIngredient> itemRecipeIngredients)
    {
        foreach (var ingredient in itemRecipeIngredients)
        {
            ItemCode itemCode = ingredient.item.itemCode;
            this.inventory.DeductItem(itemCode, ingredient.count);
        }
    }
}
