using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGrid : MonoBehaviour
{
    double maxHeight, minHeight;
    Vector3 size;
    Terrain terrain;

    private void Awake()
    {
        terrain = FindObjectOfType<Terrain>();
        size = terrain.terrainData.size;
    }
}
