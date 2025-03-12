using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : UIHotKeyAbstract
{
    // Update is called once per frame
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isPressAlpha1) this.Press(1);
        if (InputHotKeyManager.Instance.isPressAlpha2) this.Press(2);
        if (InputHotKeyManager.Instance.isPressAlpha3) this.Press(3);
        if (InputHotKeyManager.Instance.isPressAlpha4) this.Press(4);
        if (InputHotKeyManager.Instance.isPressAlpha5) this.Press(5);
        if (InputHotKeyManager.Instance.isPressAlpha6) this.Press(6);
        if (InputHotKeyManager.Instance.isPressAlpha7) this.Press(7);
    }

    protected virtual void Press(int alpha)
    {
        ItemSlot itemSlot = this.hotKeyCtrl.itemSlots[alpha-1];
        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();
        if (pressable == null) return;
        pressable.Pressed();
    }
}
