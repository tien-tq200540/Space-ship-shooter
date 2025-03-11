using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : TienMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
