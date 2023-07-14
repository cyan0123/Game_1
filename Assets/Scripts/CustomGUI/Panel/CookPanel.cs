using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPanel : Basepanel<CookPanel>
{
    int capacity = 16;
    public Item[] pacItems;
    public CookItem[] cookItems;
    public Item product;
    public Texture2D blank;
    public Texture2D soupTexture;
    public CustomGUIButton btnCreate;
    private HerbData blankHerb;
    private int cookNum;

    // Start is called before the first frame update
    void Start()
    {
        blankHerb = new HerbData("", blank, HerbData.HerbType.Qita);

        //��ȡ����UI���
        pacItems = new Item[capacity];
        string s = "pacItems/item (";
        for (int i = 0; i < capacity; i++)
        {
            pacItems[i] = transform.Find(s + (i + 1).ToString() + ")").GetComponent<Item>();
        }

        //��ȡ��ҩUI���
        cookItems = new CookItem[5];
        s = "cookItems/item (";
        for (int i = 0; i < 5; i++)
        {
            cookItems[i] = transform.Find(s + (i + 1).ToString() + ")").GetComponent<CookItem>();
            cookItems[i].idx = i;
        }
        //��ȡ����UI���
        product = transform.Find("cookItems/itemProduct").GetComponent<Item>();
        product.updataHerb(blankHerb);

        cookNum = 0;

        btnCreate.clickEvent += () =>
        {
            Create();
        };

        this.HidePanel();

    }

    void Create()
    {
        //product.updataHerb(new HerbData("�ɵ�", soupTexture,HerbData.HerbType.Soup));
        //Herb tmp = new Herb("�ɵ�", soupTexture, HerbData.HerbType.Soup);
        print(cookNum);
        if (cookNum == 5)
        {
            Package.Instance.addHerb(new Herb("�ɵ�", soupTexture, HerbData.HerbType.Soup));
            for (int i = 4; i >= 0; i--)
            {
                Cook.Instance.mark[i] = false;
                Cook.Instance.herbDatas[i] = null;
                cookItems[i].updataHerb(blankHerb);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cookNum = 0;
        //����ҩ����UI
        for (int i = 0; i < 5; i++)
        {
            if (Cook.Instance.mark[i])
            {
                cookItems[i].updataHerb(Cook.Instance.herbDatas[i]);
                cookNum++;
            }
            else
            {
                cookItems[i].updataHerb(blankHerb);
            }
        }
        //����������UI
        int len = Package.Instance.herbs.Count;
        for (int i = 0; i < len; i++)
        {
            pacItems[i].updataHerb(Package.Instance.herbs[i].herbData);
        }
        for (int i = len; i < capacity; i++)
        {
            pacItems[i].updataHerb(blankHerb);
        }


    }
}