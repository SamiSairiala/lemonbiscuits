using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTexture : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain t;
    public int posX;
    public int posZ;
    public float[] textureValues;

    public AudioClip[] grassSteps;
    public AudioClip[] sandSteps;

    private void Start()
    {
        t = Terrain.activeTerrain;
    }

    public void GetTerrainTexture()
    {
        ConvertPos(playerTransform.position);
        CheckTexture();
    }

    void ConvertPos(Vector3 playerPos)
    {
        Vector3 terrainPos = playerPos - t.transform.position;
        Vector3 mapPos = new Vector3(terrainPos.x / t.terrainData.size.x, 0, terrainPos.z / t.terrainData.size.z);
        float xCoord = mapPos.x * t.terrainData.alphamapWidth;
        float zCoord = mapPos.z * t.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    private void Update()
    {
        //GetTerrainTexture();
        //if (textureValues[0] > 0)
        //{
        //    //Debug.Log("Grass");
        //    AudioManager.Instance.RandomSoundEffect(grassSteps);
        //}
        //if (textureValues[1] > 0)
        //{
        //    //Debug.Log("Grass2");
        //    AudioManager.Instance.RandomSoundEffect(grassSteps);
        //}
        //if (textureValues[2] > 0)
        //{
        //    //Debug.Log("Dirt");
        //}
        //if (textureValues[3] > 0)
        //{
        //    //Debug.Log("Dirt with grass");
        //}
        //if (textureValues[4] > 0)
        //{
        //    //Debug.Log("Sand");
        //    AudioManager.Instance.RandomSoundEffect(sandSteps);
        //}
    }

    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);
        textureValues[0] = aMap[0, 0, 0]; // Grass
        textureValues[1] = aMap[0, 0, 1]; // Grass
        textureValues[2] = aMap[0, 0, 2]; // Dirt
        textureValues[3] = aMap[0, 0, 3]; // Dirt with grass
        textureValues[4] = aMap[0, 0, 4]; // Sand
    }
}
