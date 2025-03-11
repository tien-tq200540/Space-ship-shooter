using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : TienMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allows to exist!");
        else instance = this;
    }
}
