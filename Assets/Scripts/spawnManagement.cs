using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManagement : MonoBehaviour
{
    public GameObject[] foeList;
    public float spawnRangeX = 50;
    public float spawnPosZ = -20;
    public float spawnPosY = 44;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerMovement playerMovementScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnRandomFoe", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRandomFoe()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xPos, spawnPosY, spawnPosZ);
        //int animalIndex = Random.Range(0, animalPrefabs.Length);
        //Instantiate(foe, transform.position, spawnPos);
        int foeIndex = Random.Range(0, foeList.Length);
        GameObject randomFoe = foeList[foeIndex];

        if(playerMovementScript.isDead == false)
        {
            Instantiate(randomFoe, spawnPos, foeList[foeIndex].transform.rotation);
        }
    }
}
