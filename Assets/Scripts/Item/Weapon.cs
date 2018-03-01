using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public int Damage { get; set; }
    //public int Strength { get; set; }
    //public int Intellect { get; set; }
    //public int Agility { get; set; }
    //public int Stamina { get; set; }
    public WeaponType weaponType { get; set; }
    public Weapon(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice, int sellPrice, string sprite,int damage,WeaponType wpType): base(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite)
    {
        Damage = damage;
        weaponType = wpType;
    }
    public enum WeaponType
    {
        None,
        OffHand,
        MainHand
    }
    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string wpTypeText = "";

        switch (weaponType)
        {
            case WeaponType.OffHand:
                wpTypeText = "副手";
                break;
            case WeaponType.MainHand:
                wpTypeText = "主手";
                break;
        }

        string newText = string.Format("{0}\n\n<color=blue>武器类型：{1}\n攻击力：{2}</color>", text, wpTypeText, Damage);

        return newText;
    }
}
