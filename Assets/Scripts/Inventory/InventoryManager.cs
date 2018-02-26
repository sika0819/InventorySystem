using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class InventoryManager : Singleton<InventoryManager> {
    private List<Item> itemList=new List<Item>();
	// Use this for initialization
	void Start () {
        ResourcesTool.Init();
        Knackpack.Instance.Init(transform.Find(ResourcesTool.ResourceName.KnackpackPanel).Find(ResourcesTool.ResourceName.SlotPanel).gameObject);
        ToolTip.Instance.Init(transform.Find(ResourcesTool.ResourceName.ToolTip).gameObject);
        ParseItemJson();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ParseItemJson()
    {
        TextAsset itemText = Resources.Load<TextAsset>("json/item");
        string itemJson = itemText.text;
        JObject jObject = JObject.Parse(itemJson);
        JArray jArray = (JArray)jObject["itemList"];
        foreach (JToken jItem in jArray) {
            Item item= jItem.ToObject<Item>();
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
}
