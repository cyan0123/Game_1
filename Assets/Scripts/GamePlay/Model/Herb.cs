using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour
{
    public HerbData herbData;
    public Herb(string herbName, Texture2D texture, HerbData.HerbType herbType, int hot, int cold, int poison)
    {
        herbData = new HerbData(herbName, texture, herbType, hot, cold, poison);
    }

    public Herb(HerbData herbData)
    {
        this.herbData = herbData;
    }
}