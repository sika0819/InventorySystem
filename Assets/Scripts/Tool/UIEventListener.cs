using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger {
    public delegate void ActionHandler(GameObject go);
    public ActionHandler OnHover;
    public ActionHandler OnMouseExit;
    public ActionHandler OnMouseDown;
    public static UIEventListener GetListener(GameObject go) {
        if (go.GetComponent<UIEventListener>() == null)
        {
            go.AddComponent<UIEventListener>();
        }
        return go.GetComponent<UIEventListener>();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("鼠标进入");
    
        base.OnPointerEnter(eventData);
        if (OnHover != null)
            OnHover.Invoke(eventData.pointerEnter);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("鼠标退出");
      
        base.OnPointerExit(eventData);
        if (OnMouseExit != null)
            OnMouseExit.Invoke(eventData.pointerEnter);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (OnMouseDown != null)
            OnMouseDown.Invoke(eventData.pointerPress);
    }
}
