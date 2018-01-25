﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item {
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Agility { get; set; }
    public int Stamina { get; set; }
    public EquipmentType EquipType { get; set; }
    public Equipment(int id, string name, ItemType type, ItemQuality quality, string description, int capacity, int buyPrice,int sellPrice,string sprite,int strength,int intellect,int agility,int stamina,EquipmentType equipmentType) : base(id, name, type, quality, description, capacity, buyPrice,sellPrice, sprite)
    {
        Strength = strength;
        Intellect = intellect;
        Agility = agility;
        Stamina = stamina;
        EquipType = equipmentType;
    }
    public enum EquipmentType {
        None,
        Head,
        Neck,
        Chest,
        Ring,
        Leg,
        Bracer,
        Boots,
        Shoulder,
        Belt,
        Hand
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string equipTypeText = "";
        switch (EquipType)
        {
            case EquipmentType.Head:
                equipTypeText = "头部";
                break;
            case EquipmentType.Neck:
                equipTypeText = "脖子";
                break;
            case EquipmentType.Chest:
                equipTypeText = "胸部";
                break;
            case EquipmentType.Ring:
                equipTypeText = "戒指";
                break;
            case EquipmentType.Leg:
                equipTypeText = "腿部";
                break;
            case EquipmentType.Bracer:
                equipTypeText = "护腕";
                break;
            case EquipmentType.Boots:
                equipTypeText = "靴子";
                break;
            case EquipmentType.Shoulder:
                equipTypeText = "护肩";
                break;
            case EquipmentType.Belt:
                equipTypeText = "腰带";
                break;
            case EquipmentType.Hand:
                equipTypeText = "手";
                break;
        }

        string newText = string.Format("{0}\n\n<color=blue>装备类型：{1}\n力量：{2}\n智力：{3}\n敏捷：{4}\n体力：{5}</color>", text, equipTypeText, Strength, Intellect, Agility, Stamina);

        return newText;
    }
}