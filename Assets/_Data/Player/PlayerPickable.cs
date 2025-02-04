using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickable : PlayerAbstract
{
    public virtual void PlayerPicked(ItemPickupable itemPickupable)
    {
        if (itemPickupable == null) return;

        //Add item to inventory
        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
