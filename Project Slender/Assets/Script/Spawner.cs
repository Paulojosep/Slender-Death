using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform [] spawnPoints;
    private Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        int randomIndex = Random.Range(0, spawnPoints.Length);
        
        enemyTransform.position = spawnPoints[randomIndex].position;
    }
}
