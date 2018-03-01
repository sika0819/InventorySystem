﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {
    public int HP { get; set; }
    public int MP { get; set; }
    public Consumable(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice,int sellPrice, string sprite,int hp,int mp):base(id, name, type,quality,description,capacity,buyPrice,sellPrice, sprite)
    {
        HP = hp;
        MP = mp;
    }
    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string newText = string.Format("{0}\n\n<color=blue>加血：{1}\n加蓝：{2}</color>", text, HP, MP);

        return newText;
    }
    public override string ToString()
    {
        string s = "";
        s += Id.ToString();
        s += Type;
        s += Quality;
        s += Description;
        s += Capacity;
        s += BuyPrice;
        s += SellPrice;
        s += Sprite;
        s += HP;
        s += MP;
        return s;
    }

}
