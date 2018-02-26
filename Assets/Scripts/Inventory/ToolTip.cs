﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip {
    public static ToolTip Instance
    {
        get
        {
            return SingletonProvider<ToolTip>.Instance;
        }
    }
    GameObject ToolTipGo;
    Text MainText;
    Text ContentText;
    public void Init(GameObject go)
    {
        ToolTipGo = go;
        ToolTipGo.transform.SetParent(InventoryManager.Instance.gameObject.transform);
        MainText = ToolTipGo.GetComponent<Text>();
        ContentText = ToolTipGo.transform.Find(ResourcesTool.ResourceName.Content).GetComponent<Text>();
        HideTip();
    }
    public string TipString {
        get {
            return MainText.text;
        }
        set {
            MainText.text = value;
            ContentText.text = value;
        }
    }
    public void ShowTip(string tip) {
        ToolTipGo.SetActive(true);
        TipString = tip;
    }
    public void HideTip() {
        ToolTipGo.SetActive(false);
    }
}
