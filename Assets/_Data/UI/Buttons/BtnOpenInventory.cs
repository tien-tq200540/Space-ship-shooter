using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
