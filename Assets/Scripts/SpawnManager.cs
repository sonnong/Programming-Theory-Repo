using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private Player player;
    private float spawnRangeX = 3.5f;
    private float spawnPosY = 10f, spawnPosZ;
    private float spawnInterval = 1.5f, timer = 0f, difficultyRate = 1.01f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawnPosZ = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && MainManager.Instance.isGameActive)
        {
            SpawnRandomEnemies();
            timer = 0;
            spawnInterval /= difficultyRate; // Gradually increase spawn speed
        }
    }

    void SpawnRandomEnemies()
    {
        int enemyIndex = Random.Range(0, Enemies.Length);
        Vector3 spawnPos = new (Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(Enemies[enemyIndex], spawnPos, Enemies[enemyIndex].transform.rotation);
    }
}
