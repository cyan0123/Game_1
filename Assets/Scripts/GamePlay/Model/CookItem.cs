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
        //�������Ը���
        this.fllowBehavior();

        if (Input.GetMouseButtonUp(0))
        {
            //�����UI���� �� �ڴ˸�̧�����
            if (haveFllowingUI &&
                pointerX > this.guiPos.pos.x - this.guiPos.width / 2 &&
                pointerX < this.guiPos.width / 2 + this.guiPos.pos.x &&
                pointerY > this.guiPos.pos.y - this.guiPos.height / 2 &&
                pointerY < this.guiPos.height / 2 + this.guiPos.pos.y)
            {
                //���ò�����
                fllowingUI.setunFllow();
                //ɾ�������е�
                if(fllowingUI.GetType() ==typeof(PacItem))
                {
                    Package.Instance.updateData(fllowingUI.herbData,this.herbData);
                }else if (fllowingUI.GetType() == typeof(CookItem))
                {
                    Cook.Instance.updateData((fllowingUI as CookItem).idx, this.herbData);
                }
                
                //������ҩ���
                Cook.Instance.updateData(idx, fllowingUI.herbData);
            }
        }

    }
}
