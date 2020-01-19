using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove;
	bool jump;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f || CrossPlatformInputManager.GetAxis("Horizontal") > .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f || CrossPlatformInputManager.GetAxisRaw("Horizontal") < -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;

    }
}
