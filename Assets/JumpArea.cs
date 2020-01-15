using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController2D>().m_Grounded = false;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1500));
        }
    }
}
