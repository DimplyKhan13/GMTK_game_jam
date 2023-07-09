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
            sr.color = Color.yellow;
            space.tag = command.tag;
        }
        else
        {
            sr.color = Color.blue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        command = collider;
    }
}
