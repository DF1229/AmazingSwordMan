using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float zOffset = -10;

    [Range(1,10)]
    public float smoothingFactor = 1;

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, zOffset);
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, targetPos, smoothingFactor * Time.fixedDeltaTime);

        this.transform.position = smoothedPosition;
    }

}
