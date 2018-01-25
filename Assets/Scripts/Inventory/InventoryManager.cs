using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class InventoryManager : Singleton<InventoryManager> {

	// Use this for initialization
	void Start () {
        ParseItemJson();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ParseItemJson()
    {
        TextAsset itemText = Resources.Load<TextAsset>("json/item");
        string itemJson = itemText.text;
        ItemList itemList = JsonConvert.DeserializeObject<ItemList>(itemJson);
        Debug.Log(itemList.itemList[1].Type);
        
        
    }
}
