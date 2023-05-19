using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbData : MonoBehaviour
{
    public enum HerbType
    {
        GanCao,
        ShengJiang,
        BanLanGen,
        HuaShanShen,
        BanXia,
        BaiMaoGen
    }
    public string herbName;
    public Texture2D texture;
    public HerbType herbType;
    HerbData()
    {

    }    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
