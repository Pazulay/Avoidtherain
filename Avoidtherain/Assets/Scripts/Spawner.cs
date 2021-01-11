using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnMinMax;
    float secondsUntilNextSpawn;

    public Vector2 spawnSizeMinMax;

    Vector2 screenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        


        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        
    }

    void Spawn()
    {
        if (Time.time > secondsUntilNextSpawn) 
        {
            float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            secondsUntilNextSpawn = Time.time + secondsBetweenSpawns;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);

            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-5f, 5f)));
            newBlock.transform.localScale = Vector3.one * spawnSize;
        }
    }
}
