﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemList {
    [SerializeField]
   public List<Item> itemList=new List<Item>();
}
[Serializable]
public class Item {
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }
    /// <summary>
    /// 物品类型
    /// </summary>
   [SerializeField]
   public enum ItemType {
        Consumable,
        Equipment,
        Weapon,
        Material
   }
    [SerializeField]
    public enum ItemQuality {
        Common,
        UnCommon,
        Rare,
        Epic,
        Legendary,
        Artifact
   }

    public Item(int id,string name,ItemType type,ItemQuality quality,string description,int capacity,int buyPrice,int sellPrice,string sprite) {
        Id = id;
        Name = name;
        Type = type;
        Quality = quality;
        Description = description;
        Capacity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        Sprite = sprite;
    }
    public virtual string GetToolTipText() {
        string color = "";
        switch (Quality) {
            case ItemQuality.Common:
                color = "white";
                break;
            case ItemQuality.UnCommon:
                color = "lime";
                break;
            case ItemQuality.Rare:
                color = "navy";
                break;
            case ItemQuality.Epic:
                color = "magenta";
                break;
            case ItemQuality.Legendary:
                color = "orange";
                break;
            case ItemQuality.Artifact:
                color = "red";
                break;
        }
        string text = string.Format("<color={4}>{0}</color>\n" +
            "<size=10><color=green>购买价格：{1} 出售价格:{2}</color></size>\n" +
            "<color=yellow><size=10>{3}</size></color>",Name,BuyPrice,SellPrice,Description,color);
        return color;
    }
}
