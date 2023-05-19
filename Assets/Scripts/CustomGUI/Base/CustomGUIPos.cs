using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对齐方式
/// </summary>
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down
}
[System.Serializable]
public class CustomGUIPos
{
    private Rect rPos = new Rect(0, 0, 100, 100);
    //屏幕偏移位置
    public E_Alignment_Type screen_Alignment_Type = E_Alignment_Type.Center;
    //控件中心偏移位置
    public E_Alignment_Type control_Center_Alignment_Type = E_Alignment_Type.Center;
    //偏移位置
    public Vector2 pos;
    public float width = 100;
    public float height = 30;

    private Vector2 centerPos;
    private void CalcCenterPos()
    {
        switch (control_Center_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width ;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
            default:
                break;
        }


    }
    private void CalcPos()
    {
        float w = Screen.width;
        float h = Screen.height;
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x = w / 2 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rPos.x = w / 2 + centerPos.x + pos.x;
                rPos.y = h + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = h/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = w  + centerPos.x + pos.x;
                rPos.y = h/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = w / 2 + centerPos.x + pos.x;
                rPos.y = h/2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Up:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Down:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = h + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Up:
                rPos.x = w + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Down:
                rPos.x = w  + centerPos.x + pos.x;
                rPos.y = h + centerPos.y + pos.y;
                break;
            default:
                break;
        }
    }
    //实际位置信息
    public Rect Pos
    {
        get
        {
            CalcCenterPos();
            CalcPos();
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}