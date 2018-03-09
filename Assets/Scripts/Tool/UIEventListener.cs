using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger {
    public delegate void ActionHandler(PointerEventData go);
    public ActionHandler OnHover;
    public ActionHandler OnMouseExit;
    public ActionHandler OnMouseDown;
    public ActionHandler OnMouseBeginDrag;
    public ActionHandler OnMouseDrag;
    public ActionHandler OnMouseDragEnd;
    public ActionHandler OnMouseUp;
    public static UIEventListener GetListener(GameObject go) {
        if (go.GetComponent<UIEventListener>() == null)
        {
            go.AddComponent<UIEventListener>();
        }
        return go.GetComponent<UIEventListener>();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (OnHover != null)
            OnHover.Invoke(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {  
        base.OnPointerExit(eventData);
        if (OnMouseExit != null)
            OnMouseExit.Invoke(eventData);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (OnMouseDown != null)
            OnMouseDown.Invoke(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        if (OnMouseUp != null)
            OnMouseUp.Invoke(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (OnMouseBeginDrag != null)
            OnMouseBeginDrag.Invoke(eventData);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (OnMouseDrag != null)
            OnMouseDrag.Invoke(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (OnMouseDragEnd != null)
        {
            OnMouseDragEnd.Invoke(eventData);
        }
    }

}
