using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Basepanel<GamePanel>
{
    //»ñÈ¡¿Ø¼þ
    public CustomGUITexture texHp;
    public float HPWidth;

    [HideInInspector]
    public int nowScore;
    [HideInInspector]
    public float nowTIme = 0;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
}
