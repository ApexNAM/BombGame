using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public float speed = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(Vector3.Distance(target.position,transform.position) < 10f)
        {
            Vector3 trans = target.position - transform.position;
            rb.AddForce(trans * speed * Time.deltaTime);
        }
    }
}
