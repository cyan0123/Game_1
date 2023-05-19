using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{
    private static Package instance = new Package();
    public static Package Instance => instance;

    private List<HerbData> herbDatas = new List<HerbData>();
    public void addHerb(HerbData herbData)
    {
        herbDatas.Add(herbData);
    }
    public void delHerb(HerbData herbData)
    {
        herbDatas.Remove(herbData);
    }


}
