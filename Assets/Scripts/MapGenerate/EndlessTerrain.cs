using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const int maxVieDst = 450;
    public Transform viewer;
    public static Vector2 viewerPosition;
    static MapGenerator mapGenerator;

    int chunkSize;
    int chunkVisbleInViewDst;

    Dictionary<Vector2, TerrainChunk> terrainChunkDic = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();
    void Start()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
        chunkSize = MapGenerator.mapChunkSize - 1;
        chunkVisbleInViewDst = Mathf.RoundToInt(maxVieDst/chunkSize);
    }

    private void Update()
    {
        viewerPosition = new Vector2(viewer.position.x,viewer.position.z);
        UpdateVisbleChunks();
    }

    void OnMapDataRecived(MapData mapData)
    {
        print("fff");
    }

    private void UpdateVisbleChunks()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisibel(false);
        }
        terrainChunksVisibleLastUpdate.Clear();
        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x/chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);
        for (int yOffset = -chunkVisbleInViewDst; yOffset < chunkVisbleInViewDst; yOffset++)
        {
            for (int xOffset = -chunkVisbleInViewDst; xOffset < chunkVisbleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset); ;
                
                if(terrainChunkDic.ContainsKey(viewedChunkCoord)){
                    terrainChunkDic[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDic[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDic[viewedChunkCoord]);
                    }
                }
                else{
                    terrainChunkDic.Add(viewedChunkCoord,new TerrainChunk(viewedChunkCoord,chunkSize,transform));
                }
            }
        }
    }
    public class TerrainChunk
    {
        GameObject meshObj;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 coord, int size, Transform parent)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);

            meshObj = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObj.transform.position = positionV3;
            meshObj.transform.localScale = Vector3.one * size / 10f;
            meshObj.transform.parent = parent;

            SetVisibel(false);

            //mapGenerator.RequestMapdata(OnMapDataRecived);
        }

        public void UpdateTerrainChunk()
        {
            float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
            bool visibel = viewerDstFromNearestEdge <= maxVieDst;
            SetVisibel(visibel);
        }
        public void SetVisibel(bool visible)
        {
            meshObj.SetActive(visible);
        }

        public bool IsVisible()
        {
            return meshObj.activeSelf;
        }
    }



}
;
