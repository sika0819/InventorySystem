using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger {
    public delegate void ActionHandler(GameObject go);
    ActionHandler OnHover;
    public static UIEventListener GetListener(GameObject go) {
        if (go.GetComponent<UIEventListener>() == null)
        {
            go.AddComponent<UIEventListener>();
        }
        return go.GetComponent<UIEventListener>();
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        OnHover.Invoke(eventData.hovered[0]);
        base.OnPointerEnter(eventData);
    }
}
