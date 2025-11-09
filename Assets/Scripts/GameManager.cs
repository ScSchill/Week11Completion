using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab; // Added for Enemy 3

    // Start is called before the first frame update
    void Start()
    {
        // Spawn Enemy 1 every 2 seconds starting after 1 second
        InvokeRepeating("CreateEnemyOne", 1, 2);
        
        // Spawn Enemy 2 every 3 seconds starting after 2 seconds
        InvokeRepeating("CreateEnemyTwo", 2, 3);

        // Spawn Enemy 3 every 4 seconds starting after 3 seconds
        InvokeRepeating("CreateEnemyThree", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        // No changes needed here
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}
