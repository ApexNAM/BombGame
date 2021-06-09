using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        float LookX = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(0, 0, z * 15f * Time.deltaTime);
        transform.Rotate(Vector3.up * LookX * 100f * Time.deltaTime);

        if(z != 0 || LookX != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if(collision.collider.tag == "Obstacle")
        {
            animator.SetTrigger("damage");
            GameManager.instance.AddScore(-1);
        }

        if (collision.collider.tag == "Enemy")
        {
            animator.SetTrigger("attack01");
            GameManager.instance.OnPlayerDead();
        }
    }
}
