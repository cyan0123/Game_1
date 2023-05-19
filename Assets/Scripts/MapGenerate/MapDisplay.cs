using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    //通过控制plane的Renderer来控制地形的显示
    public Renderer textureRender;
    public MeshFilter meshFilter;
    public MeshRenderer meshRender;
    //绘制噪声图
    public void DrawTexture(Texture2D texture)
    {
        //将应用后的图交给Randerer去展现效果
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    

    internal void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRender.sharedMaterial.mainTexture = texture;
    }
}

