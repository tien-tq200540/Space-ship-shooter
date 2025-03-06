using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadContent();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log($"{transform.name}: LoadContent", gameObject);
    }
}
