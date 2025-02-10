using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickable : PlayerAbstract
{
    public virtual void PlayerPicked(ItemPickupable itemPickupable)
    {
        if (itemPickupable == null) return;

        //Add item to inventory
        ItemInventory itemInventory = itemPickupable.ItemCtrl.CurItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
