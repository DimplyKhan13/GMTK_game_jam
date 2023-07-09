using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField] 
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private LayerMask commandLayer;

    private GameObject grabbedCommand = null;

    private RaycastHit2D hitInfo;



    void Update()
    {
        if (player.localScale.x >= 0)
        {
            hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance, commandLayer);
        }
        else 
        {
            hitInfo = Physics2D.Raycast(rayPoint.position, -1f*transform.right, rayDistance, commandLayer);
        }

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.F) && grabbedCommand == null) 
            {
                grabbedCommand = hitInfo.collider.gameObject;
                grabbedCommand.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedCommand.transform.position = grabPoint.position;
                grabbedCommand.transform.SetParent(transform);
            }
            else if(Input.GetKeyDown(KeyCode.F)) 
            {
                
                grabbedCommand.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedCommand.transform.SetParent(null);
                grabbedCommand = null;
            }
        }

        if (player.localScale.x >= 0)
        {
            Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        }
        else
        {
            Debug.DrawRay(rayPoint.position, -transform.right * rayDistance);
        }
        

    }
}
