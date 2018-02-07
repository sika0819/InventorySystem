using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.G)) {
            int id = (int)Random.Range(1, InventoryManager.Instance.ListCount+1);
            Knackpack.Instance.StoreItem(id);
        }
	}
}
