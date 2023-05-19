using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUILabel : CustomGUIControl
{
    public override void StyleOffDraw()
    {
        GUI.Label(guiPos.Pos, content);
    }

    public override void StyleOnDraw()
    {
        GUI.Label(guiPos.Pos, content,style);
    }
}
