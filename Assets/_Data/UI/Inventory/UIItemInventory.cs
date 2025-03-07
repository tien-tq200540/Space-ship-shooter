using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIItemInventory : TienMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected TMPro.TMP_Text itemName;
    public TMPro.TMP_Text ItemName => itemName;

    [SerializeField] protected TMPro.TMP_Text itemNumber;
    public TMPro.TMP_Text ItemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemName();
        LoadItemNumber();
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
        Debug.Log($"{transform.name}: LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<TMP_Text>();
        Debug.Log($"{transform.name}: LoadItemNumber", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = item.itemProfile.name;
        this.itemNumber.text = item.itemCount.ToString();
    }
}
