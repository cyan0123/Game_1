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
        Qita
    }
    public string herbName;
    public Texture2D texture;
    public HerbType herbType;
    public HerbData(string herbName, Texture2D texture, HerbType herbType)
    {
        this.herbName = herbName;
        this.texture = texture;
        this.herbType = herbType;
    }
}
