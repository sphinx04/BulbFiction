using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SetRadius : MonoBehaviour
{
    public float radiusMultiplyer = 5f;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Light2D>().pointLightOuterRadius = 1.5f +
            gameObject.transform.parent.GetComponent<CharacterController2D>().energy / 10f;
        
        gameObject.GetComponent<Light2D>().pointLightInnerRadius =
            gameObject.GetComponent<Light2D>().pointLightOuterRadius / radiusMultiplyer;
    }
}
