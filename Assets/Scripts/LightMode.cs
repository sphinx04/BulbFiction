using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightMode : MonoBehaviour
{
    private Light2D mLight;
    public float defaultIntensity = 2f;
    public float randomizer;
    [Range(0f, 1f)]
    public float deltaLight = 0.03f;
    [Range(0f, 1f)]
    public float flickSpeed = 0.5f;
    
    void Start()
    {
        mLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mLight.intensity = defaultIntensity * (1 + (Mathf.Pow(-1, Mathf.RoundToInt((Mathf.PerlinNoise(Time.deltaTime * flickSpeed, 1f) * 10000f)/randomizer)))*deltaLight);
    }
}
