using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PackagePanel : Basepanel<PackagePanel> 
{
    int capacity = 16;
    public Item[] items;
    public Texture2D blank;

    private HerbData blankHerb;

    // Start is called before the first frame update
    void Start()
    {
        blankHerb = new HerbData("", blank, HerbData.HerbType.Qita);

        items = new Item[capacity];
        string s = "items/item (";

        for (int i = 0; i < capacity; i++)
        {
            items[i] = transform.Find(s + (i + 1).ToString()+")").GetComponent<Item>();
        }
        this.HidePanel();

    }

    // Update is called once per frame
    void Update()
    {
        int len = Package.Instance.herbs.Count;
        for (int i = 0; i < len; i++)
        {
            items[i].updataHerb(Package.Instance.herbs[i].herbData);
        }
        for (int i = len; i < capacity; i++)
        {
            items[i].updataHerb(blankHerb);
        }
    }
}
    