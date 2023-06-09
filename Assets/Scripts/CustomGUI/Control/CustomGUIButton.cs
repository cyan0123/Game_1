using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    public event UnityAction clickEvent;

    public override void StyleOffDraw()
    {
        if(GUI.Button(guiPos.Pos,content))
        {
            clickEvent?.Invoke();
        }
    }

    public override void StyleOnDraw()
    {
        if (GUI.Button(guiPos.Pos, content,style))
        {
            clickEvent?.Invoke();
        }
    }


   
}
