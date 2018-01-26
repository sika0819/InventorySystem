using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI {//物品显示UI
    public GameObject uiTarget;
    public Item item;
    private Image itemImage;
    private Text amount;//显示数量
    public ItemUI(GameObject go) {
        uiTarget = go;
    }
    public void InitItem(Item item) {
        this.item = item;
        itemImage = uiTarget.GetComponent<Image>();
        itemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        amount = uiTarget.GetComponent<Text>();
        amount.text = item.Capacity.ToString();
    }
}
