using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.orthographicSize > 50f)
        {
            cam.orthographicSize -= 0.05f;
        }
    }


}
