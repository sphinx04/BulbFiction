using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public Joystick joystick;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update () {

        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //horizontalMove = joystick.Horizontal * runSpeed;





        if (joystick.Horizontal > .2f || Input.GetAxisRaw("Horizontal") > 0f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal < -.2f || Input.GetAxisRaw("Horizontal") < 0f)
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
        if (joystick.Vertical > .5f)
		{
			jump = true;
		}

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


    //void FixedUpdate ()
    //{
    //	// Move our character
    //	controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    //	jump = false;
    //}
}
