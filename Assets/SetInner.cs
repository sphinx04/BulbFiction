using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SetInner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Light2D>().pointLightInnerRadius = gameObject.GetComponent<Light2D>().pointLightOuterRadius * .2f;
    }
}
