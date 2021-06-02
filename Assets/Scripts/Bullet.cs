using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    private float enableTime = 0f;
    private float lifeTime = 10f;
    private Vector3 poolPos = new Vector3(50, -50, 50);
    private Transform playerTrans;

    private void Start()
    {
        gameObject.SetActive(false);
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    private void OnEnable()
    {
        enableTime = Time.time;
    }

    private void Update()
    {
        if(Time.time > enableTime + lifeTime)
        {
            transform.position = poolPos;
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(playerTrans.forward * speed * Time.deltaTime);
        }
    }
}
