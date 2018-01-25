using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Agility { get; set; }
    public int Stamina { get; set; }
    public Weapon(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice, int sellPrice, string sprite,int damage): base(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite)
    {

    }
    public enum WeaponType
    {
        MainHand,
        OffHand
    }
}
