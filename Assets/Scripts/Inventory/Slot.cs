using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot {//物品槽类
    GameObject slotGo;
    public Item item;//存储物品
    ItemUI itemUI;
    public Slot(GameObject go) {
        slotGo = go;
    }
    

    public bool StoreItem(Item item)
    {
        if (item==null)
        {
            this.item = item;
            return true;
        }
        else if (this.item.Equals(item))
        {//序号一致则可以增加数量
            this.item.Capacity += item.Capacity;
            return true;
        }
        return false;
    }
    public bool isEmpty() {
        if (item == null)
            return true;
        return false;
    }
}
