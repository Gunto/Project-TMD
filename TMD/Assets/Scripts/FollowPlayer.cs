using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothing;
    private Vector3 velocity = Vector3.zero;

    // private void LateUpdate()
    // {
    //     Vector3 targetPosition = target.position - offset;
    //     transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing * Time.deltaTime);
    // }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position - offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing * Time.fixedDeltaTime);
    }
}
