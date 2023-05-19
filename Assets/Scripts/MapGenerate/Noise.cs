using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    //定义一个函数生成地图 利用噪声来设置地形的长宽大小等属性
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        //定义一个两个维度的浮点数类型的数组 用于存储长、宽数据
        float[,] noiseMap = new float[mapWidth, mapHeight];
        //防止地图的大小出现负数
        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        //对传入的函数的长、宽参数进行灰度值赋值 模拟噪声
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                //除以scale 让影响scale的同时能够影响到地图缩放的大小
                float sampleX = x / scale;
                float sampleY = y / scale;

                //柏林值 Mathf.PerlinNoise可以简单理解为随机获得在这个点的灰度值
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                //将灰度值返回给这个点
                noiseMap[x, y] = perlinValue;
            }
        }
        return noiseMap;
    }
}

