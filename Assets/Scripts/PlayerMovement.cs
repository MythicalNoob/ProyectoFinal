using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    #region Old Input

    //public float speed;
    //public Transform mPlayer;

    //private void FixedUpdate()
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();

    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    Vector3 foward = Camera.main.transform.forward;
    //    Vector3 right = Camera.main.transform.right;

    //    foward.y = 0;
    //    right.y = 0;

    //    Vector3 MoveDirection = foward * verticalInput + right * horizontalInput;

    //    rb.velocity = new Vector3(MoveDirection.x * speed, rb.velocity.y, MoveDirection.z * speed);

    //    if (MoveDirection != new Vector3(0,0,0))
    //    {
    //        mPlayer.rotation = Quaternion.LookRotation(MoveDirection);
    //    }
    //}

    #endregion

    [SerializeField] float speed;
    [SerializeField] Vector3 playerDir;
    [SerializeField] Transform mPlayer;
    [SerializeField] float rotSpeed;
    [SerializeField] float rotDir;
    #region Server

    [Command]
    void CmdMove(Vector2 move)
    {
        var dir = new Vector3(0, 0, move.y);
        playerDir = dir;

        rotDir = move.x;

    }

    [ServerCallback]
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * playerDir);
        transform.Rotate(rotSpeed * rotDir * Time.deltaTime * Vector3.up);
    }

    #endregion

    #region Client

    public void Movement(InputAction.CallbackContext context)
    {
        if (!hasAuthority) { return; }

        Vector2 move = context.ReadValue<Vector2>();
        

        CmdMove(move);
    }

    #endregion
}
