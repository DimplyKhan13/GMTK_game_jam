using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer button;
    [SerializeField]
    private Collider2D col;
    [SerializeField]
    private Collider2D player;

    // Update is called once per frame
    void Update()
    {
        if (col.IsTouching(player) && Input.GetKeyDown(KeyCode.Space))
        {
            button.color = Color.green;
        }
    }

}
