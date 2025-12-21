using UnityEngine;

public class Terrgen : MonoBehaviour
{
    public int width = 513;
    public int height = 513;
    public float scale = 50f;

    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        TerrainData terrainData = terrain.terrainData;

        terrainData.heightmapResolution = width;
        terrainData.size = new Vector3(scale, 50, scale);

        float[,] heights = GenerateHeights();
        terrainData.SetHeights(0, 0, heights);
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                float nx = (float)x / width * 2 - 1;
                float ny = (float)y / height * 2 - 1;

                heights[x, y] = (Mathf.Sin(nx * 4f + Mathf.Cos(ny * 8f)) + Mathf.Cos(ny * 4f - Mathf.Sin(nx * 8f))) * 0.1f + 0.2f;

            }
        }

        return heights;
    }
}