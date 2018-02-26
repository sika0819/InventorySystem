using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class Item {
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }//容量
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
            "<size=60><color=blue>购买价格：{1} 出售价格:{2}</color></size>\n" +
            "<color=yellow><size=60>{3}</size></color>",Name,BuyPrice,SellPrice,Description,color);
        return text;
    }
    public bool Equals(Item item)
    {
        return Id==item.Id;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("ID:" + Id+"\n");
        sb.Append("名称:" + Name+"\n");
        sb.Append("类型:");
        switch (Type) {
            case ItemType.Consumable:
                sb.Append("消耗品\n");
                break;
            case ItemType.Equipment:
                sb.Append("装备品\n");
                break;
            case ItemType.Material:
                sb.Append("材料\n");
                break;
            case ItemType.Weapon:
                sb.Append("武器\n");
                break;
        }
        sb.Append("品质:");
        switch (Quality)
        {
            case ItemQuality.Common:
                sb.Append("普通\n");
                break;
            case ItemQuality.UnCommon:
                sb.Append("特殊\n");
                break;
            case ItemQuality.Rare:
                sb.Append("稀有\n");
                break;
            case ItemQuality.Epic:
                sb.Append("高级\n");
                break;
            case ItemQuality.Legendary:
                sb.Append("传说\n");
                break;
            case ItemQuality.Artifact:
                sb.Append("远古\n");
                break;
        }
        return sb.ToString();
    }
}
