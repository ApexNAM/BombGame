using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    private int count = 30; 
    private GameObject[] enermys;

    void Start()
    {
        enermys = new GameObject[count];
        for (int i = 0; i < count; i++) 
        { 
            Vector3 pos = new Vector3(Random.Range(-30, 30), transform.position.y, Random.Range(-30, 30)); 
            enermys[i] = Instantiate(enemyPrefab, pos, Quaternion.identity); 
        }
    }
}
