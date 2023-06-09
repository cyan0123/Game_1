using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPanel : Basepanel<PickupPanel>
{
    CustomGUIButton[] btnHrebs;
    public Texture2D blank;


    // Start is called before the first frame update
    void Start()
    {
        btnHrebs = GetComponentsInChildren< CustomGUIButton>();
        this.HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        //拾取界面
        for (int i = 0; i < Pickup.Instance.herbs.Count && i<4; i++)
        {
            btnHrebs[i].content.text = Pickup.Instance.herbs[i].herbData.herbName;
            btnHrebs[i].content.image = Pickup.Instance.herbs[i].herbData.texture;
        }
        for(int i = Pickup.Instance.herbs.Count; i <4; i++)
        {
            btnHrebs[i].content.text = "";
            btnHrebs[i].content.image = blank;
        }
        //按E拾取
        if(Input.GetKeyUp(KeyCode.E))
        {
            Pickup.Instance.pickup();
        }
    }

    private void pickupAll(List<HerbData> herbDatas)
    {
        for (int i = herbDatas.Count-1; i > -1 ; i--)
        {
            pickup(herbDatas[i]);
        }
    }
    private void pickup(HerbData herbData)
    {
        //if (Package.Instance.herbDatas.Count >= 16) return;
        //Package.Instance.addHerb(herbData);
        //Pickup.Instance.delHerb(herbData);
        //Destroy(herb.gameObject);
        //if(PickupPanel.Instance.herbDatas.Count == 0)
        //{
        //    PickupPanel.Instance.HidePanel();
        //}
    }
}
