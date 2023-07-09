using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    [SerializeField]
    private GameObject space;
    [SerializeField] 
    private SpriteRenderer sr;
    [SerializeField]
    private Collider2D col;
    [SerializeField]
    private LayerMask commandLayer;

    private Collider2D command;

    // Update is called once per frame
    void Update()
    {
        if (col.IsTouchingLayers(commandLayer))
        {
            space.tag = command.tag;
        }
        else
        {
            space.tag = "Empty";
        }

        if (space.tag == "Untagged")
        {
            sr.color = Color.red;
        }
        else if (space.tag == "Empty")
        {
            sr.color = Color.blue;
        }
        else
        {
            sr.color = Color.green;
        }


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        command = collider;
    }
}
