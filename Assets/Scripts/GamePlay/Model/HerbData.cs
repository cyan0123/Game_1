using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class HerbData
{
    public enum HerbType
    {
        GanCao,
        ShengJiang,
        BanLanGen,
        HuaShanShen,
        BanXia,
        BaiMaoGen,
        Soup,
        Qita,
        GuiZhi,
        ShaoYao,
        DaZao,
        GanJiang
    }
    public string herbName;
    public Texture2D texture;
    public HerbType herbType;
    public int hot;
    public int cold;
    public int poison;

    public HerbData(string herbName, Texture2D texture, HerbType herbType)
    {
        this.herbName = herbName;
        this.texture = texture;
        this.herbType = herbType;
    }
    public HerbData(string herbName, Texture2D texture, HerbType herbType, int hot, int cold, int poison)
    {
        this.herbName = herbName;
        this.texture = texture;
        this.herbType = herbType;
        this.hot = hot;
        this.cold = cold;
        this.poison = poison;
    }
}
