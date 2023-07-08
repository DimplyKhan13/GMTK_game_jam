using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer button;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 8 && Input.GetKeyDown(KeyCode.Space))
        {
            button.color = Color.green;
        }
    }
}
