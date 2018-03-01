using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItem : Item {
    public MaterialItem(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice, int sellPrice, string sprite, int hp, int mp) : base(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite)
    {
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

        return s;
    }
}
