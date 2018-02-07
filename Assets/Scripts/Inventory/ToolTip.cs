using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip  {
    GameObject ToolTipGo;
    Text MainText;
    Text ContentText;
    public ToolTip(GameObject go) {
        ToolTipGo = GameObject.Instantiate<GameObject>(go);
        ToolTipGo.transform.SetParent(InventoryManager.Instance.gameObject.transform);
    }
}
