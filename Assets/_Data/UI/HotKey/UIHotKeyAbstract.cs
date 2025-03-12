using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : TienMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl hotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIHotKeyCtrl();
    }

    protected virtual void LoadUIHotKeyCtrl()
    {
        if (this.hotKeyCtrl != null) return;
        this.hotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.Log($"{transform.name}: LoadUIHotKeyCtrl", gameObject);
    }
}
