using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : CustomGUIButton
{
    //����Ƿ��и����UI
    public static bool haveFllowingUI;
    //���ڸ����UI
    public static Item fllowingUI; 
    //��UI�Ƿ��ڸ���
    private bool isFllow = false;
    public HerbData herbData;
    //��¼��UI��ƫ����
    Vector2 offsetTmp;
    
    //��������
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
        
        //�������
        if (Input.GetMouseButtonDown(0))
        {
            //����ڰ�ť��Χ��
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
            //̧�����
            if (Input.GetMouseButtonUp(0))
            {
                setunFllow();
                //��ⰴť�Ƿ��ϳ�����
                //if (this.guiPos.pos.x < -500 / 2 || this.guiPos.pos.x > 500 / 2 ||
                //    this
                if (this.guiPos.pos.x < -Bk.guiPos.width / 2 || this.guiPos.pos.x > Bk.guiPos.width / 2 ||
                this.guiPos.pos.y < -Bk.guiPos.height / 2 || this.guiPos.pos.y > Bk.guiPos.height / 2)
                {
                    //ֱ��ɾ�������е���Ʒ
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