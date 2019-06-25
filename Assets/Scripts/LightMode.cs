using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightMode : MonoBehaviour
{
    private Light2D mLight;
    //public float defaultIntensity = 2f;
    //public float randomizer;
    //[Range(0f, 1f)]
    //public float deltaLight = 0.03f;
    //[Range(0f, 1f)]
    //public float flickSpeed = 0.5f;
    public float frequency = 0.1f;
    public float phaseOffset = 0f;
    public float amplitude = 1f;

    void Start()
    {
        mLight = GetComponent<Light2D>();
        //phaseOffset = Random.Range(-Mathf.PI, Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        mLight.intensity = 1 + Mathf.Sin(Time.fixedTime * Mathf.PI * frequency + phaseOffset) * amplitude;

    }
}
