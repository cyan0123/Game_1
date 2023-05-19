using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    
    public static Texture2D TextureFromColorMap(Color[]colorMap,int w,int h)
    {
        Texture2D texture = new Texture2D(w,h);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,]heightMap)
    {
        //用来获取数组指定维数中的元素个数 这里分别是长和宽
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        //Color类型是接收的是一个[0,1]的值，需要用R，G，B，A四个值各自除以255
        //这里是定义整张图的取值面积 即要修改颜色点的多少
        Color[] colourMap = new Color[width * height];

        //将每个点赋值色彩
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Color.Lerp插值，获取0，1之间的一个值
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColorMap(colourMap, width,height);
    }
}
