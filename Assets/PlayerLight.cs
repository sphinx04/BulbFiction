using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerLight : MonoBehaviour
{
    [Range(0f, 2f)]
    public float defaultIntensity;
    [Range(0f, 1f)]
    public float additionalIntensity;
    private Rigidbody2D rb;
    private Light2D playerLight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLight.intensity = Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y) ? 
            defaultIntensity + Mathf.Abs(rb.velocity.x) * additionalIntensity : 
            defaultIntensity + Mathf.Abs(rb.velocity.y) * additionalIntensity;
    }
}
