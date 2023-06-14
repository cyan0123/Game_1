using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacItem : Item
{
    private void Start()
    {
        Bk = transform.parent.transform.parent.transform.Find("BK/BK").GetComponent<CustomGUITexture>();
        ItemRenderContol.Instance.allItems.Add(this);
    }
    // Update is called once per frame
    void Update()
    {
        fllowBehavior();

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
                if (fllowingUI.GetType() == typeof(CookItem))
                {
                    HerbData tmp = fllowingUI.herbData;
                    Cook.Instance.updateData((fllowingUI as CookItem).idx, this.herbData);
                    //������ҩ���
                    Package.Instance.updateData(this.herbData, tmp);
                }
                else if (fllowingUI.GetType() == typeof(PacItem))
                {
                    HerbData tmp = fllowingUI.herbData;
                    fllowingUI.herbData = this.herbData;
                    //������ҩ���
                    Package.Instance.updateData(this.herbData, tmp);
                }
            }
        }
    }
}