using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger {
    public delegate void ActionHandler();
    public ActionHandler OnHover;
    public ActionHandler OnMouseExit;
    public static UIEventListener GetListener(GameObject go) {
        if (go.GetComponent<UIEventListener>() == null)
        {
            go.AddComponent<UIEventListener>();
        }
        return go.GetComponent<UIEventListener>();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if(OnHover!=null)
        OnHover.Invoke();
        base.OnPointerEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (OnMouseExit != null)
            OnMouseExit.Invoke();
        base.OnPointerExit(eventData);

    }
}
