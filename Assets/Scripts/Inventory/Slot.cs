﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot {//物品槽类
    GameObject slotGo;
    public Item item;//存储物品
    public ItemUI itemUI;
    public Slot(GameObject go) {
        slotGo = go;
        UIEventListener.GetListener(slotGo).OnHover = ShowTip;
        UIEventListener.GetListener(slotGo).OnMouseExit = HideTip;
        UIEventListener.GetListener(slotGo).OnMouseDown = OnMouseDown;
    }
    

    public bool StoreItem(Item item,int amount=1)
    {
        if (this.item==null)
        {
            this.item = item;
            itemUI = new ItemUI(slotGo,item,amount);
            return true;
        }
        else if (this.item.Equals(item))
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
    public bool isEmpty() {
        if (item == null)
            return true;
        return false;
    }
    public Item.ItemType GetItemType()
    {
        return itemUI.item.Type;
    }
    public bool IsFilled()
    {
        return itemUI.Amount >= item.Capacity;
    }
    public void ShowTip(GameObject go)
    {
        ToolTip.Instance.ShowTip(item.GetToolTipText());
    }
    public void HideTip(GameObject go)
    {
        ToolTip.Instance.HideTip();
    }
    public void OnMouseDown(GameObject go) {
        ItemUI currentItem = itemUI;
        InventoryManager.Instance.SetItem(itemUI);
    }
}
