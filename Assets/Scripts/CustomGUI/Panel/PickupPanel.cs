using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPanel : Basepanel<PickupPanel>
{
    private List<HerbData> herbDatas= new List<HerbData>();
    CustomGUIButton[] btnHrebs;

    public void addHerb(HerbData herbData)
    {
        //print(herbData.herbName);
        herbDatas.Add(herbData);
    }
    public void delHerb(HerbData herbData)
    {
        herbDatas.Remove(herbData);
    }
    // Start is called before the first frame update
    void Start()
    {
        btnHrebs = GetComponentsInChildren<CustomGUIButton>();
        
        this.HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < herbDatas.Count; i++)
        {
            btnHrebs[i].content.text = herbDatas[i].herbName;
            btnHrebs[i].content.image = herbDatas[i].texture;
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            //for (int i = 0; i < herbDatas.Count; i++)
            //    print(herbDatas[i].herbName);
            pickupAll(herbDatas);
        }

    }

    private void pickupAll(List<HerbData> herbDatas)
    {
        for (int i = 0; i < herbDatas.Count; i++)
        {
            //print("Ö´ÐÐ");
            //print(herbDatas[i].herbName);
            pickup(herbDatas[i]);
        }
        for (int i = 0; i < herbDatas.Count; i++)
        {
            this.delHerb(herbDatas[i]);
        }
    }
    private void pickup(HerbData herb)
    {
        Package.Instance.addHerb(herb);
        //this.delHerb(herb);
        herb.gameObject.SetActive(false);
    }
}
