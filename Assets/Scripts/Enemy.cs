using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject explosionEffect;

    public Transform target;
    private Rigidbody rb;
    public float speed = 20f;

    private bool scored = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Vector3.Distance(target.position, transform.position) < 10f)
        {
            Vector3 tar = target.position - transform.position;
            rb.AddForce(tar * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Bullet" && !scored)
        {
            audioSource.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            scored = true;
            GameManager.instance.AddScore(1);
            transform.position = new Vector3(Random.Range(-30,30),0.5f,Random.Range(-30, 30));
            scored = false;
        }
    }
}
