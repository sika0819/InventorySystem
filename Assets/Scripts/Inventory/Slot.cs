using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot {//物品槽类
    public GameObject slotGo;
    //public Item item;//存储物品
    public ItemUI itemUI;
    public bool isDrag=false;
    public Slot(GameObject go) {
        slotGo = go;
        UIEventListener.GetListener(slotGo).OnHover = ShowTip;
        UIEventListener.GetListener(slotGo).OnMouseExit = HideTip;
        UIEventListener.GetListener(slotGo).OnMouseBeginDrag = OnBeginDrag;
        UIEventListener.GetListener(slotGo).OnMouseDrag= OnDrag;
        UIEventListener.GetListener(slotGo).OnMouseDragEnd = OnEndDrag;
    }
    

    public bool StoreItem(Item item,int amount=1)
    {
        if (itemUI==null)
        {
            itemUI = new ItemUI(slotGo,item,amount);
            return true;
        }
        else if (itemUI.item.Equals(item))
        {//序号一致则可以增加数量
            if (!IsFilled())
            {
                itemUI.AddAmount(amount);
                return true;
            }
            else {
                Debug.LogWarning("背包已满"+item.Name);
            }
        }
        return false;
    }
    public bool SetItem(ItemUI itemUI) {
        if (itemUI!=null&& SetItem(itemUI.item, itemUI.Amount))
            return true;
        return false;
    }
    public bool SetItem(Item item, int amount = 1) {
        if (itemUI == null)
        {
            itemUI = new ItemUI(slotGo, item, amount);
            return true;
        }
        else {
            itemUI.InitItem(item,amount);
        }
        return false;
    }
    public bool isEmpty() {
        if (itemUI == null)
            return true;
        return false;
    }
    public Item.ItemType GetItemType()
    {
        return itemUI.item.Type;
    }
    public bool IsFilled()
    {
        return itemUI.Amount >= itemUI.item.Capacity;
    }
    public void ShowTip(PointerEventData go)
    {
        if(itemUI!=null)
        ToolTip.Instance.ShowTip(itemUI.item.GetToolTipText());
    }
    public void HideTip(PointerEventData go)
    {
        ToolTip.Instance.HideTip();
    }

    public void SetActive(bool active) {
        if(itemUI!=null)
        itemUI.SetActive(active);
    }
    public void Destory() {
        if (itemUI != null)
        {
            itemUI.Destory();
            itemUI = null;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)//开始拖拽
    {
        if (itemUI != null)
        {
            ItemUI currentItem = itemUI;
            if (Input.GetKey(KeyCode.LeftControl))
            {
                InventoryManager.Instance.SetPickedItem(itemUI, itemUI.Amount / 2);
            }
            else {
                InventoryManager.Instance.SetPickedItem(itemUI, itemUI.Amount);
            }
            ObjFollowMouse(eventData);//让生成的物体跟随鼠标
            SetActive(false);
        }
    }
    public void OnDrag(PointerEventData eventData)//拖拽中
    {
        InventoryManager.Instance.PickedItem.ObjFollowMouse(eventData);//让生成的物体跟随鼠标
        ToolTip.Instance.HideTip();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
     
        if (eventData.pointerCurrentRaycast.gameObject!=null&& eventData.pointerCurrentRaycast.gameObject.tag == "Slot" && eventData.pointerCurrentRaycast.gameObject != slotGo)
        {
            Slot slot = InventoryManager.Instance.GetSlotByGameObject(eventData.pointerCurrentRaycast.gameObject);
            
            if (slot.itemUI == null)
            {
                slot.SetItem(itemUI);
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    InventoryManager.Instance.PickedItem.SetActive(false);
                    Destory();
                }
            }
            else {

                SetItem(slot.itemUI);
                slot.SetItem(InventoryManager.Instance.PickedItem.itemUI);
                InventoryManager.Instance.PickedItem.SetActive(false);
            }
        }
        else {
            SetActive(true);
            InventoryManager.Instance.PickedItem.SetActive(false);
        }
      
    }//拖拽结束
    private void ObjFollowMouse(PointerEventData eventData)
    {
        if (InventoryManager.Instance.PickedItem.slotGo != null)//检测生成的物体是否为空，保险起见
        {
            RectTransform rc = InventoryManager.Instance.PickedItem.slotGo.GetComponent<RectTransform>();//得到生成物品的控制权
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle
                (InventoryManager.Instance.canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                rc.position = globalMousePos;
            }
        }
    }
}
