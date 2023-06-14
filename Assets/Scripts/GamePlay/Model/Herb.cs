using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour
{
    public HerbData herbData;
    public Herb(string herbName, Texture2D texture, HerbData.HerbType herbType)
    {
        herbData = new HerbData(herbName, texture, herbType);
    }

    public Herb(HerbData herbData)
    {
        this.herbData = herbData;
    }
}