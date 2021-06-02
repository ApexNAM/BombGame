using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int count = 100;
    public GameObject bulletPrefabs;
    public Transform firePoint;

    public Vector3 fireVectorPos;

    private Transform playerPos;
    private GameObject[] bullets;
    private int index = 0;

    private void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        bullets = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            bullets[i] = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        transform.position = playerPos.position;

        if (GameManager.instance.isGameOver)
        {
            Destroy(gameObject);
        }

        if (Input.GetButton("Fire1"))
        {
            transform.position += fireVectorPos * 50f * Time.deltaTime;
            bullets[index].transform.position = firePoint.position;
            bullets[index].SetActive(true);
            index++;
            index %= count;
        }
    }
}
