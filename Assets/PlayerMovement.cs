using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public Joystick joystick;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
    private float tmpInt;
    bool jump = false;
    bool flipGravity = false;

    // Update is called once per frame
    void Update () {

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = joystick.Horizontal * runSpeed;

        tmpInt = ChangeIntensity();
        controller.currentEnergy -= tmpInt * 0.04f;
        controller.playerLight.intensity = (controller.defaultIntensity + tmpInt) * controller.currentEnergy / controller.DefaultEnergy;

        if (Input.GetButtonDown("Jump"))
		{
            Jump();
		}

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, flipGravity);
		jump = false;
	}

    public void Jump()
    {
        jump = true;
    }
    public void FlipGravity()
    {
        flipGravity = true;
    }

    float ChangeIntensity()
    {
        return Mathf.Abs(controller.m_Rigidbody2D.velocity.x) > Mathf.Abs(controller.m_Rigidbody2D.velocity.y) ?
Mathf.Abs(controller.m_Rigidbody2D.velocity.x) * controller.additionalIntensity * controller.defaultIntensity :
Mathf.Abs(controller.m_Rigidbody2D.velocity.y) * 0.5f * controller.additionalIntensity * controller.defaultIntensity;
    }
}
