using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI {//物品显示UI
    #region Data
    public GameObject uiTarget;
    public Item item;
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
            amountText.text = amount.ToString();
        }
    }
    private int amount = 0;
    #endregion
    #region UIComponent
    private Image itemImage;//物品图标
    private Text amountText;//显示物品数量

    public Image ItemImage {
        get {
            return itemImage;
        }
    }
    public Text AmountText {
        get {
            return amountText;
        }
    }
    #endregion
    /// <summary>
    /// 初始化方法
    /// </summary>
    /// <param name="go"></param>
    public ItemUI(GameObject go) {
        uiTarget = GameObject.Instantiate(ResourcesTool.GetResoureGameObject(ResourcesTool.ResourceName.itemPrefab)); 
        uiTarget.transform.SetParent(go.transform);
        uiTarget.transform.localPosition = Vector3.zero;
        uiTarget.transform.localScale = Vector3.one;
   
    }
    public void InitItem(Item item,int amount=1) {
        this.item = item;
        itemImage = uiTarget.GetComponent<Image>();
        itemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        amountText = uiTarget.GetComponentInChildren<Text>();
        Amount = amount;

    }
    public void AddAmount(int amount = 1) {
        Amount += amount;
    }
    
}
