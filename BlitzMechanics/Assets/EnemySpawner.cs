using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyList;
    [SerializeField] private GameObject topLeftLimit;
    [SerializeField] private GameObject bottomRightLimit;
    [SerializeField] private int maxSpawnedEnemies;
    public static int currentSpawnedEnemies;
    [SerializeField] private float secondsForSpawn;
    [SerializeField] private float timeSinceLastSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        timeSinceLastSpawn = secondsForSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastSpawn < 0)
        {
            if (currentSpawnedEnemies < maxSpawnedEnemies && BlitzController.firingArm == false)
            {
                timeSinceLastSpawn = secondsForSpawn;
                currentSpawnedEnemies++;
                

                GameObject enemy = Instantiate(enemyList[UnityEngine.Random.Range(0, enemyList.Length)],this.gameObject.transform);
                float xPos = UnityEngine.Random.Range(topLeftLimit.transform.position.x, bottomRightLimit.transform.position.x);
                float yPos = UnityEngine.Random.Range(bottomRightLimit.transform.position.y, topLeftLimit.transform.position.y);
                enemy.transform.position = Vector3.up * yPos + Vector3.right * xPos;
            }
        }
        else
        {

            timeSinceLastSpawn = timeSinceLastSpawn - Time.deltaTime;
        }
    }
}
