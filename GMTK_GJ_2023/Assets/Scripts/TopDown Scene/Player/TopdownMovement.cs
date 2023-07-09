using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private float horizontalMove;
    private float verticalMove;

    [HideInInspector]
    public bool isFacingRight = true;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform playerTransform;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;

        playerTransform.position= new Vector3(
            Mathf.Clamp(playerTransform.position.x, -169f, 172f),
            Mathf.Clamp(playerTransform.position.y, -99f, 65f),
            0);

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}