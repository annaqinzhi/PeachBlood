using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed=0.5f;
    public Vector3 offset;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.fixedDeltaTime);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
