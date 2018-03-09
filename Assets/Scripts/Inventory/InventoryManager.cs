using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class InventoryManager : Singleton<InventoryManager> {
    private List<Item> itemList=new List<Item>();
    private List<Weapon> weaponList = new List<Weapon>();//兵装库
    private List<Equipment> equipList = new List<Equipment>();//装备库
    private List<Material> materialList = new List<Material>();
    private List<Consumable> consumList = new List<Consumable>();//消耗库
    public List<Slot> slotList = new List<Slot>();
    [HideInInspector]
    public Canvas canvas;
    #region 选择的物体
    private Slot pickedItem;
    public Slot PickedItem {
        get {
            return pickedItem;
        }
    }
    #endregion
    // Use this for initialization
    void Start () {
        ResourcesTool.Init();
        Knackpack.Instance.Init(transform.Find(ResourcesTool.ResourceName.KnackpackPanel).Find(ResourcesTool.ResourceName.SlotPanel).gameObject);
        Chest.Instance.Init(transform.Find(ResourcesTool.ResourceName.Chest).Find(ResourcesTool.ResourceName.SlotPanel).gameObject);
        ToolTip.Instance.Init(transform.Find(ResourcesTool.ResourceName.ToolTip).gameObject);
        canvas = GameObject.FindObjectOfType<Canvas>();
        pickedItem = new Slot(null,transform.Find(ResourcesTool.ResourceName.PickedItem).gameObject);
        ParseItemJson();
    }
	
	// Update is called once per frame
	void Update () {
        if (ToolTip.Instance.isTipShow) {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition,Camera.main,out pos);
            ToolTip.Instance.SetPos(pos);
        }

	}
    void ParseItemJson()
    {
        TextAsset itemText = Resources.Load<TextAsset>("json/item");
        string itemJson = itemText.text;
        JObject jObject = JObject.Parse(itemJson);
        JArray jArray = (JArray)jObject["itemList"];
        foreach (JToken jItem in jArray) {
            Item item= jItem.ToObject<Item>();
            switch (item.Type) {
                case Item.ItemType.Consumable:
                    item = jItem.ToObject<Consumable>();
                    break;
                case Item.ItemType.Equipment:
                    item = jItem.ToObject<Equipment>();
                    break;
                case Item.ItemType.Weapon:
                    item = jItem.ToObject<Weapon>();
                    break;
                case Item.ItemType.Material:
                    item = jItem.ToObject<MaterialItem>();
                    break;
                default:
                    break;
            }
            itemList.Add(item);
        }
    }
    
    public Item GetItemById(int id)
    {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].Id == id) {
                return itemList[i];
            }
        }
        return null;
    }
    public int ListCount {
        get {
            return itemList.Count;
        }
    }
    public void SetPickedItem(ItemUI itemUI,int Amount) {
        pickedItem.SetItem(itemUI.item, Amount);
        itemUI.Amount = itemUI.Amount - Amount;
    }
    public void SetPickedItemPos(Vector3 pos) {
        pickedItem.slotGo.transform.localPosition = pos;
    }

    public Slot GetSlotByGameObject(GameObject gameObject)
    {
        for (int i = 0; i < slotList.Count; i++) {
            if (slotList[i].slotGo == gameObject)
                return slotList[i];
        }
        return null;
    }
}
