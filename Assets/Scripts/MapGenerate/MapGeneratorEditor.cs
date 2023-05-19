using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//将我们定义好的控件展示出来
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public bool mapGenChange = true;
    

    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        //修改参数不用运行就能看到修改后的效果
        if (DrawDefaultInspector())
        {
            if (mapGenChange)
            {
                mapGen.DrawMapInEditor();
            }
        }

        //点击按键就能更新
        if (GUILayout.Button("Generate"))
        {
            mapGen.DrawMapInEditor();
        }
    }
}
