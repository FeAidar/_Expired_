using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float runSpeed = 40f;
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public CharacterController2D controller;
    private Rigidbody2D _rigidbody;

    float horizontalMove = 0f;
    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (!Mathf.Approximately(0, horizontalMove))
            transform.rotation = horizontalMove > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
        }
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;


    }
}
