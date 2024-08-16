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
    private float startDelay = 2f, spawnInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawnPosZ = player.transform.position.z;
        InvokeRepeating(nameof(SpawnRandomEnemies), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemies()
    {
        int enemyIndex = Random.Range(0, Enemies.Length);
        Vector3 spawnPos = new (Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        Instantiate(Enemies[enemyIndex], spawnPos, Enemies[enemyIndex].transform.rotation);
    }
}
