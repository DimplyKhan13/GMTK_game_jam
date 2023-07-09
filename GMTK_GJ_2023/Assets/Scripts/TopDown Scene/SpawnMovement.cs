using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    [SerializeField]
    private Collider2D col;
    [SerializeField]
    private LayerMask threadmillLayer;

    // Update is called once per frame
    void Update()
    {
        if (col.IsTouchingLayers(threadmillLayer) && (transform.position.x < -125))
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
    }
}
