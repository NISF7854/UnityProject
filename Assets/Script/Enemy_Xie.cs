using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Xie : Entity
{
    [Header("Attack")]
    [SerializeField] private bool isAttacking;



    [Header("Move Info")]
    [SerializeField] private float moveSpeed;

    [Header("Player Detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;
    private RaycastHit2D isPlayerDetection;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Move();

        
    }
    //³¡¾°ÓëÍæ¼ÒÅö×²¼ì²â
    protected override void CollisionCheck()
    {
        base.CollisionCheck();
        isPlayerDetection = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }



    //ÒÆ¶¯
    private void Move()
    {
        
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
        if (!isGrounded || isWallDetected)
        {
            Filp();
        }
    }
}
