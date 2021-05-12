using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float LookX = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(0, 0, z * 15f * Time.deltaTime);
        transform.Rotate(Vector3.up * LookX * 100f * Time.deltaTime);
    }
}
