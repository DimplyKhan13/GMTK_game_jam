using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    [SerializeField]
    private Transform cam;

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -97f, 99f),
            Mathf.Clamp(targetToFollow.position.y +21, -57f, 53f),
            cam.position.z);
    }
}
