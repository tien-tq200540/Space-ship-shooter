using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : TienMonoBehaviour
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 UIInventory allows to exist!");
        else instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Close();
    }

    protected virtual void FixedUpdate()
    {
        this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (isOpen) Open();
        else Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        int itemCount = PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count;
    }
}
