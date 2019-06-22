using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bulb")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
