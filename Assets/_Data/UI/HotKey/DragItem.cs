using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : TienMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;
    public Transform RealParent { set => this.realParent = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.Log($"{transform.name}: LoadImage", gameObject);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
       this.realParent = transform.parent;
       transform.SetParent(UIHotKeyCtrl.Instance.transform);
       this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }
}
