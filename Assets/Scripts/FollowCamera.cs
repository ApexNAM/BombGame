using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float dis = 5.0f;
    public float height = 4.0f;

    private void LateUpdate()
    {
        transform.position = target.position - (target.forward * dis) + (Vector3.up * height);
        transform.LookAt(target);
    }
}
