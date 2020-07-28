﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    private float repeatRate = 2;
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;

    public GameObject coinPrefab;
    private Vector3 coinSpawnPos = new Vector3(25, 3, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            Instantiate(coinPrefab, coinSpawnPos, coinPrefab.transform.rotation);
        }
    }
}
