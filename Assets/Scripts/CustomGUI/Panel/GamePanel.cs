using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;
public class GamePanel : Basepanel<GamePanel>
{
    //获取控件
    public Item[] terms ;
    public Texture2D blank;

    private MouseLook mouseLook;
    public CustomGUITexture nowBk;
    public int nowItem;

    private HerbData blankHerb;
    private int texWidth = 240;
    private CustomGUITexture texHot;
    private CustomGUITexture texCold;
    private CustomGUITexture texPoison;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
        //获取物品格
        terms = new Item[4];
        string s = "Terms/Term";
        for (int i = 0; i < 4; i++)
        {
            terms[i] = transform.Find(s + (i + 1).ToString()).GetComponent<Item>();
        }

        blankHerb = new HerbData("", blank, HerbData.HerbType.Qita);
        texHot = transform.Find("TexHot").GetComponent<CustomGUITexture>();
        texCold = transform.Find("TexCold").GetComponent<CustomGUITexture>();
        texPoison = transform.Find("TexPoison").GetComponent<CustomGUITexture>();
    }

    // Update is called once per frame
    void Update()
    {
        //填充物品格
        int len = Package.Instance.herbs.Count;
        for (int i = 0; i < len && i<4; i++)
        {
            terms[i].updataHerb(Package.Instance.herbs[i].herbData);
        }
        for (int i = len; i < 4; i++)
        {
            terms[i].updataHerb(blankHerb);
        }

        //打开关闭背包
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (PackagePanel.Instance.gameObject.activeSelf)
            {
                PackagePanel.Instance.HidePanel();
                mouseLook.SetCursorLock(true);

            }
            else
            {
                PackagePanel.Instance.ShowPanel();
                mouseLook.SetCursorLock(false);
            }
        }
        

        int scroll = (int)(Input.GetAxis("Mouse ScrollWheel") / 0.1f);
        if (scroll < 0)
        {
            nowBk.guiPos.pos.x = nowBk.guiPos.pos.x + 70 > 105 ? -105 : nowBk.guiPos.pos.x + 70;
            nowItem = (nowItem + 1) % 4;
        }
        else if (scroll > 0)
        {
            nowBk.guiPos.pos.x = nowBk.guiPos.pos.x - 70 < -105 ? 105 : nowBk.guiPos.pos.x - 70;
            nowItem = nowItem - 1 >= 0 ? nowItem - 1 : 3;
        }
        //丢弃物品
        if (Input.GetKeyUp(KeyCode.Q))
        {
            terms[nowItem].delHerb(terms[nowItem].herbData);
        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            ChaMove.Instance.StartEat();
        }
        /*if (Input.GetKeyUp(KeyCode.G))
        {
            ChaMove.Instance.EndEat();
        }*/

        //更新血条
        texHot.guiPos.width = texWidth / 5 * PlayerState.Instance.hot;
        texCold.guiPos.width = texWidth / 5 * PlayerState.Instance.cold;
        texPoison.guiPos.width = texWidth / 5 * PlayerState.Instance.poison;
    }

}
