using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{//背包、宝箱基类
    public List<Slot> slotList = new List<Slot>();
    public GameObject targetObj;
    public virtual void Init(GameObject go) {//初始化方法
        targetObj = go; 
        for (int i = 0; i < go.transform.childCount; i++) {
            Slot slot = new Slot(this,targetObj.transform.GetChild(i).gameObject);
            slotList.Add(slot);
        }
        InventoryManager.Instance.slotList.AddRange(slotList);
    }
    public bool StoreItem(int id) {
        Item item = InventoryManager.Instance.GetItemById(id);
        return StoreItem(item);
    }
    public bool StoreItem(Item item) {
        if (item == null) {
            Debug.LogWarning("要存储的物品ID不存在");
            return false;
        }
        Slot slot = FindSlot(item);
        if (slot == null)
        {
            Debug.LogWarning("物品槽已经满了");
            return false;
        }
        else
        {
            slot.StoreItem(item);
            return true;
        }
    }

    private Slot FindSlot(Item item)//找到一个可以放物品的槽
    {
        for (int i = 0; i < slotList.Count; i++) {
            if (slotList[i].isEmpty()||(item.Equals(slotList[i].itemUI.item)&&!slotList[i].IsFilled())) {
                return slotList[i];
            }
        }
        return null;
    }
    public Slot GetSlotByGameObject(GameObject go)
    {

        foreach (Slot item in slotList)
        {
            if (item.slotGo.Equals(go))
                return item;
        }

        return null;
    }
    public void LoadInventory() {

    }
    public void Hide() {

    }
}
