using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public FacingDirection FacingDirection = FacingDirection.Right;

    public GameObject DeathParticles = null;

    private new Rigidbody2D rigidbody = null;
    private GroundCheckerScript groundChecker = null;
    private WallCheckerScript wallChecker = null;

    public const float JumpForce = 15f;
    public const float WallJumpForce = 15f;
    public const float MoveForce = 10f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundCheckerScript>();
        wallChecker = GetComponentInChildren<WallCheckerScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Kill();
        }
    }
    private void Update()
    {
        if (FacingDirection == FacingDirection.Right)
        {
            if (InputHelper.IsSwitchDirectionDown() || InputHelper.IsLeftDown())
            {
                FacingDirection = FacingDirection.Left;
            }
            if (InputHelper.IsJumpDown())
            {
                if (groundChecker.Grounded)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
                }
                else if (wallChecker.Walled)
                {
                    FacingDirection = FacingDirection.Left;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, WallJumpForce);
                }
            }
            transform.localScale = new Vector3(1f, 1f, 1f);
            rigidbody.velocity = new Vector2(MoveForce, rigidbody.velocity.y);
        }
        else
        {
            if (InputHelper.IsSwitchDirectionDown() || InputHelper.IsRightDown())
            {
                FacingDirection = FacingDirection.Right;
            }
            if (InputHelper.IsJumpDown())
            {
                if (groundChecker.Grounded)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
                }
                else if (wallChecker.Walled)
                {
                    FacingDirection = FacingDirection.Right;
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, WallJumpForce);
                }
            }
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rigidbody.velocity = new Vector2(MoveForce * -1, rigidbody.velocity.y);
        }
    }
    public void Kill()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
