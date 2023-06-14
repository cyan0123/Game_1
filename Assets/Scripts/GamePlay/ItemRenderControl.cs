using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderContol
{
    public List<Item> allItems = new List<Item>(); 
    private static ItemRenderContol instance;

    public static ItemRenderContol Instance
    {
        get
        {
            if (instance == null) instance = new ItemRenderContol();
            return instance;
        }
    }
}
