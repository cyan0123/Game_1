using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook
{
    private static Cook instance = new Cook();
    public static Cook Instance => instance;

    public HerbData[] herbDatas = new HerbData[5];
    public bool[] mark = new bool[5];
    //public void addHerb(Herb herb)
    //{
    //    for
    //}
    //public void delHerb(Herb herb)
    //{
    //    this.herbs.Remove(herb);
    //}
    //public void delHerb(HerbData herbData)
    //{
    //    for (int i = 0; i < herbs.Count; i++)
    //    {
    //        if (herbData == this.herbs[i].herbData)
    //        {
    //            this.herbs.Remove(this.herbs[i]);
    //        }
    //    }

    //}

    public void updateData(int i, HerbData newData)
    {
        //Debug.Log(i + newData.herbName);
        this.herbDatas[i] = newData;
        mark[i] = true;
    }
}
