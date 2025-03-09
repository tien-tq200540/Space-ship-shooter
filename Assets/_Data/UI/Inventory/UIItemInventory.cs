using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : TienMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected TMPro.TMP_Text itemName;
    public TMPro.TMP_Text ItemName => itemName;

    [SerializeField] protected TMPro.TMP_Text itemNumber;
    public TMPro.TMP_Text ItemNumber => itemNumber;

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemName();
        LoadItemNumber();
        LoadItemImage();
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

    protected virtual void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").GetComponent<Image>();
        Debug.Log($"{transform.name}: LoadItemImage", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = item.itemProfile.name;
        this.itemNumber.text = item.itemCount.ToString();
        this.itemImage.sprite = item.itemProfile.sprite;
    }
}
