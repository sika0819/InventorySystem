using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knackpack :Inventory {
    public static Knackpack Instance {
        get {
            return SingletonProvider<Knackpack>.Instance;
        }
    }
}
