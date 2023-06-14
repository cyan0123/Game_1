using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookItem : Item
{
    private void Start()
    {
        Bk = transform.parent.transform.parent.transform.Find("BK/BK").GetComponent<CustomGUITexture>();
        ItemRenderContol.Instance.allItems.Add(this);
    }
    public int idx;
    private void Update()
    {
        //基本属性跟随
        this.fllowBehavior();

        if (Input.GetMouseButtonUp(0))
        {
            //如果有UI跟随 且 在此格抬起鼠标
            if (haveFllowingUI &&
                pointerX > this.guiPos.pos.x - this.guiPos.width / 2 &&
                pointerX < this.guiPos.width / 2 + this.guiPos.pos.x &&
                pointerY > this.guiPos.pos.y - this.guiPos.height / 2 &&
                pointerY < this.guiPos.height / 2 + this.guiPos.pos.y)
            {
                //设置不跟随
                fllowingUI.setunFllow();
                //删除背包中的
                if(fllowingUI.GetType() ==typeof(PacItem))
                {
                    Package.Instance.updateData(fllowingUI.herbData,this.herbData);
                }else if (fllowingUI.GetType() == typeof(CookItem))
                {
                    Cook.Instance.updateData((fllowingUI as CookItem).idx, this.herbData);
                }
                
                //更新炼药面板
                Cook.Instance.updateData(idx, fllowingUI.herbData);
            }
        }

    }
}
