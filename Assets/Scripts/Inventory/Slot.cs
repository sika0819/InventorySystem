using DG.Tweening;
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
    Inventory inventory;//所属类
    public Slot(Inventory inventory, GameObject go) {
        this.inventory = inventory;
        slotGo = go;
        UIEventListener.GetListener(slotGo).OnHover = OnMouseEnter;
        UIEventListener.GetListener(slotGo).OnMouseBeginDrag = OnBeginDrag;
        UIEventListener.GetListener(slotGo).OnMouseDrag= OnDrag;
        UIEventListener.GetListener(slotGo).OnMouseDragEnd = OnEndDrag;
        UIEventListener.GetListener(slotGo).OnMouseExit = OnMouseExit;
    }

    

    public bool StoreItem(Item item,int amount=1)
    {
        if (itemUI==null)
        {
            itemUI = new ItemUI(slotGo,item,amount);
            return true;
        }
        else
        {//序号一致则可以增加数量
            if (itemUI.item.Equals(item))
            {
                if (!IsFilled())
                {
                    itemUI.AddAmount(amount);
                    return true;
                }
                else
                {
                    Debug.LogWarning("背包已满" + item.Name);
                }
            }
            else {
                if (!IsFilled())
                {
                    itemUI.InitItem(item, amount);
                }
                else {
                    Debug.LogWarning("背包已满" + item.Name);
                }
            }
        }
        return false;
    }
    public bool SetItem(ItemUI itemUI) {
        if (itemUI != null && SetItem(itemUI.item, itemUI.Amount))
        {
            return true;
        }
        return false;
    }
    public bool SetItem(ItemUI itemUI,int amount)
    {
        if (itemUI != null && SetItem(itemUI.item, amount))
            return true;
        return false;
    }
    public bool SetItem(Item item, int amount = 1) {
        if (itemUI == null)
        {
            itemUI = new ItemUI(slotGo, item, amount);
            slotGo.transform.DOPunchScale(Vector3.one * 1.1f, 0.5f, 10, 0);
            return true;
        }
        else {
            itemUI.InitItem(item,amount);
            slotGo.transform.DOPunchScale(Vector3.one * 1.1f, 0.5f, 10, 0);
            return true;
        }

    }
    public bool isEmpty() {
        if (itemUI == null || itemUI.Amount == 0)
        {
            return true;
        }
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
    public void OnMouseEnter(PointerEventData go)
    {
        if (itemUI != null)
        {
            ToolTip.Instance.ShowTip(itemUI.item.GetToolTipText());
          
        }
    }
    public void OnMouseExit(PointerEventData go) {
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
            InventoryManager.Instance.PickedItem.DoScale(1.1f, 0.2f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (itemUI.Amount / 2 > 0)
                {
                    InventoryManager.Instance.SetPickedItem(itemUI, itemUI.Amount / 2);
                }
                else {
                    InventoryManager.Instance.SetPickedItem(itemUI, itemUI.Amount);
                }
            }
            else {
                InventoryManager.Instance.SetPickedItem(itemUI, itemUI.Amount);
            }
            ObjFollowMouse(eventData);//让生成的物体跟随鼠标
         
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
            if (slot.isEmpty())
            {//目标槽为空
                slot.SetItem(InventoryManager.Instance.PickedItem.itemUI);
            }
            else {
                if (Input.GetKey(KeyCode.LeftControl))
                {//结束时按着ctrol
                    if (!slot.IsFilled()&& InventoryManager.Instance.PickedItem.itemUI.Equals(slot.itemUI))
                    {
                        if (slot.itemUI.item.Capacity - slot.itemUI.Amount >= 0)
                        {
                            InventoryManager.Instance.PickedItem.itemUI.Amount -= 1;
                            slot.itemUI.AddAmount(1);
                        }
                        SetItem(InventoryManager.Instance.PickedItem.itemUI);
                    }
                    else {//背包满了，把物品装回原来的位置
                        itemUI.AddAmount(InventoryManager.Instance.PickedItem.itemUI.Amount);
                    }
                }
                else {
                    if (!InventoryManager.Instance.PickedItem.itemUI.Equals(slot.itemUI))
                    {
                        SetItem(slot.itemUI);
                        slot.SetItem(InventoryManager.Instance.PickedItem.itemUI);
                    }
                    else {
                        if (slot.itemUI.item.Capacity - InventoryManager.Instance.PickedItem.itemUI.Amount > 0)
                        {
                            slot.itemUI.AddAmount(InventoryManager.Instance.PickedItem.itemUI.Amount);
                        }
                        else
                        {
                            SetItem(InventoryManager.Instance.PickedItem.itemUI);
                        }
                    }
                }
            }
        }
        else {//没有移动到任何物体上
            SetItem(InventoryManager.Instance.PickedItem.itemUI);
        }
        InventoryManager.Instance.PickedItem.SetActive(false);

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
    public void DoScale(float endValue,float duration) {
        if(itemUI!=null)
        itemUI.uiTarget.transform.DOScale(new Vector3(endValue,endValue,endValue),duration).SetEase(Ease.Linear);
    }
}
