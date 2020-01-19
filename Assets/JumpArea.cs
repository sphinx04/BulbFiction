using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArea : MonoBehaviour
{
    public float jumpImpulse = 30;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("jmp");
            //collision.gameObject.GetComponent<CharacterController2D>().m_Grounded = false;
            //collision.gameObject.GetComponent<CharacterController2D>().Move(0, false);
            //if(collision.gameObject.GetComponent<CharacterController2D>().m_Grounded)
            //    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30f);
        }
    }
}
