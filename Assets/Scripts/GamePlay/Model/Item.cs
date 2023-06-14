using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : CustomGUIButton
{
    //鼠标是否有跟随的UI
    public static bool haveFllowingUI;
    //正在跟随的UI
    public static Item fllowingUI; 
    //本UI是否在跟随
    private bool isFllow = false;
    public HerbData herbData;
    //记录本UI的偏移量
    Vector2 offsetTmp;
    
    //整个背景
    public CustomGUITexture Bk;

    public void setFllow()
    {
        isFllow = true;
        fllowingUI = this;
        haveFllowingUI = true;
        offsetTmp = this.guiPos.pos;
    }
    public void setunFllow()
    {
        isFllow = false;
        haveFllowingUI = true;
        this.guiPos.pos = offsetTmp;
    }

    private void Start()
    {
        Bk = transform.parent.transform.parent.transform.Find("BK/BK").GetComponent<CustomGUITexture>();

    }
    [HideInInspector]
    public float pointerX;
    [HideInInspector]
    public float pointerY;
    public void fllowBehavior()
    {

        //print(this.gameObject.name + ": " + herb.herbName);
        if (herbData == null )
        {
            return;
        }
        

        pointerX = Input.mousePosition.x - Screen.width / 2;
        pointerY = Screen.height / 2 - Input.mousePosition.y;
        
        //按下鼠标
        if (Input.GetMouseButtonDown(0))
        {
            //点击在按钮范围内
            if (pointerX > this.guiPos.pos.x - this.guiPos.width / 2 &&
                pointerX < this.guiPos.width / 2 + this.guiPos.pos.x &&
                pointerY > this.guiPos.pos.y - this.guiPos.height / 2 &&
                pointerY < this.guiPos.height / 2 + this.guiPos.pos.y)
            {
                setFllow();

            }
        }
        if (isFllow)
        {
            PushTop();
            this.guiPos.pos.x = pointerX;
            this.guiPos.pos.y = pointerY;
            //抬起鼠标
            if (Input.GetMouseButtonUp(0))
            {
                setunFllow();
                //检测按钮是否被拖出背包
                //if (this.guiPos.pos.x < -500 / 2 || this.guiPos.pos.x > 500 / 2 ||
                //    this
                if (this.guiPos.pos.x < -Bk.guiPos.width / 2 || this.guiPos.pos.x > Bk.guiPos.width / 2 ||
                this.guiPos.pos.y < -Bk.guiPos.height / 2 || this.guiPos.pos.y > Bk.guiPos.height / 2)
                {
                    //直接删除背包中的物品
                    this.delHerb(herbData);
                }
            }
        }
    }

    private void Update()
    {
        fllowBehavior();
    }

    internal void updataHerb(HerbData herbData)
    {
        this.herbData = herbData;
        this.content.tooltip = this.herbData.herbName;
        this.style.normal.background = this.herbData.texture;
    }
    internal void delHerb(HerbData herbData)
    {
        Package.Instance.delHerb(herbData);
    }

    public void PushTop()
    {
        ItemRenderContol.Instance.allItems.Remove(this);
        ItemRenderContol.Instance.allItems.Add(this);
    }

}