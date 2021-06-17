using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    public DistanceJoint2D playerjoint;

    private int jump = 0;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
        player.mass = 0.1F;
        player.gravityScale = 2;
    }

    // Update is called once per frame
    private bool IsGrounded()
    {
        RaycastHit2D temp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - GetComponent<BoxCollider2D>().bounds.extents.y - 0.1F), -Vector2.up, 0.1F,8);
        return temp.collider != null;
    }
    void Update()
    {
        playerjoint.distance = ManagerVariables.length;
        player.AddForce(new Vector2(player.velocity.x * -0.1F, 0));
        if (ManagerVariables.player == true)
        {
            if (Input.GetKey(KeyCode.A))
                player.AddForce(new Vector2(-1, 0));
            if (Input.GetKey(KeyCode.D))
                player.AddForce(new Vector2(1, 0));
            if (IsGrounded())
            {
                if (!(jump > 0))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        player.AddForce(new Vector2(0, 75));
                        jump = 20;
                    }
                }
            }
            jump--;
        }
        if (transform.position.y < -100)
            Manager.die();
    }
}
