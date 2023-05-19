using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIInput : CustomGUIControl
{
    private event UnityAction<string> textChange;
    private string oldstr = "";
    public override void StyleOffDraw()
    {
        content.text = GUI.TextField(guiPos.Pos,content.text);
        if(oldstr != content.text)
        {
            textChange?.Invoke(content.text);
            oldstr = content.text;
        }
    }

    public override void StyleOnDraw()
    {
        content.text = GUI.TextField(guiPos.Pos, content.text,style);
        if (oldstr != content.text)
        {
            textChange?.Invoke(content.text);
            oldstr = content.text;
        }
    }
}
