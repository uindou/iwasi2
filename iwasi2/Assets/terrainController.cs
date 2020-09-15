using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = this.gameObject.GetComponent<Terrain>();
              // 1-2. サイズを設定する
        terrain.terrainData.size = new Vector3(400, 100, 300);
 
        // 2-1. ヘイトマップの解像度を設定する
        terrain.terrainData.heightmapResolution = 257;
 
        // ★★★ 追加 2-1.5. Terrainの高さを0にする
        ClearHeightMap(terrain, 257);
 
        // 2-2. ヘイトマップを取得する
        float[,] heightmap = terrain.terrainData.GetHeights(0, 0, 257, 257);
 
        // 2-3. (2,1) の高さを10にする
        int x1 = 2 * 256 / 400;
        int z1 = 1 * 256 / 300;
        heightmap[z1, x1] = 10F / 100;
 
        // 2-4. ヘイトマップを設定する
        terrain.terrainData.SetHeightsDelayLOD(0, 0, heightmap);
 
        // ★★★ 追加 2-5. (20,10) を開始点として、山を設定する
        float[,] heightmap2 = new float[20, 10]
        {
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
            {0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F, 0.2F},
        };
 
        terrain.terrainData.SetHeightsDelayLOD(20 * 256 / 400, 10 * 256 / 300, heightmap2);
    }
 
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ClearHeightMap( Terrain t, int r)
    {
        float[,] heightmap = t.terrainData.GetHeights(0, 0, r, r);
        for ( int i = 0; i<r; i++)
        {
            for (int j = 0; j<r; j++)
            {
                heightmap[j, i] = 0;
            }
        }
        
        t.terrainData.SetHeightsDelayLOD(0, 0, heightmap);
    }
}
