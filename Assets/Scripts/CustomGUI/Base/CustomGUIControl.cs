using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_OnOff
{
    on,
    off
}

public abstract class CustomGUIControl : MonoBehaviour
{
    //位置信息
    public CustomGUIPos guiPos;
    //内容信息
    public GUIContent content;
    //自定义样式
    public GUIStyle style;
    //自定义样式是否启用
    public E_Style_OnOff styleOnOROff = E_Style_OnOff.off;

    public void DrawGUI()
    {
        switch (styleOnOROff)
        {
            case E_Style_OnOff.on:
                StyleOnDraw();
                break;
            case E_Style_OnOff.off:
                StyleOffDraw();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 自定义开启时绘制方法
    /// </summary>
    public abstract void StyleOnDraw();
    /// <summary>
    /// 自定义关闭时绘制方法
    /// </summary>
    public abstract void StyleOffDraw();
}
