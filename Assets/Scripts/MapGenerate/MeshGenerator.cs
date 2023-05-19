using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float mul,AnimationCurve curve,int levelOfDetail)
    {
        int w = heightMap.GetLength(0);
        int h = heightMap.GetLength(1);

        float topLeftX = (w - 1) / -2f;
        float topLeftZ = (h - 1) / 2f;
        
        int meshSimplificationIncerement = (levelOfDetail==0)?1:levelOfDetail * 2;
        int verticesPerLine = (w - 1) / meshSimplificationIncerement+1;

        MeshData meshData = new MeshData(verticesPerLine,verticesPerLine);
        int vertexIdx = 0;
        for (int y = 0; y < h; y+=meshSimplificationIncerement)
        {
            for (int x = 0; x < w; x+=meshSimplificationIncerement)
            {
                meshData.vertices[vertexIdx] = new Vector3(topLeftX + x, curve.Evaluate(heightMap[x, y]) * mul, topLeftZ - y);
                meshData.uvs[vertexIdx] = new Vector2(x / (float)w, y / (float)h); ;
                if (x < w - 1 && y < h - 1)
                {
                    meshData.AddTriangle(vertexIdx, vertexIdx + verticesPerLine + 1, vertexIdx + verticesPerLine);
                    meshData.AddTriangle(vertexIdx + verticesPerLine + 1, vertexIdx, vertexIdx + 1);
                }
                vertexIdx++;
            }
        }
        return meshData;
    }
    
}

public class MeshData {
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;
    int triangleIndex;

    public MeshData(int w,int h)
    {
        vertices = new Vector3[w * h];
        uvs = new Vector2[w * h];
        triangles = new int[(w - 1) * (h - 1) * 6];
    }
    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex+1] = b;
        triangles[triangleIndex+2] = c;
        triangleIndex += 3;
    }
    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        return mesh;
    }
}

