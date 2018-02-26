using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesTool  {
    public static class ResourceName {
        public static string itemPrefab = "Item";
        public static string SlotPanel = "SlotPanel";
        public static string KnackpackPanel = "KnackpackPanel";
        public static string ToolTip="ToolTip";
        public static string Content = "Content";
    }
    public static void Init() {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>("Prefab");
        for (int i = 0; i < gameObjects.Length; i++) {
            dictionary.Add(gameObjects[i].name, gameObjects[i]);
        }
    }
    static Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
    public static GameObject GetResoureGameObject(string name) {
        return dictionary[name];
    }
   
}
