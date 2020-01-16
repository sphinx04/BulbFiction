using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SetRadius : MonoBehaviour
{
    public float radiusMultiplyer = 5f;
    private float InnerRadius;
    private float OuterRadius;
    // Update is called once per frame
    void Update()
    {
        OuterRadius = 1f + gameObject.transform.parent.GetComponent<CharacterController2D>().energy / 10f;
        
        InnerRadius = OuterRadius / radiusMultiplyer;

        gameObject.GetComponent<Light2D>().pointLightInnerRadius = InnerRadius;
        gameObject.GetComponent<Light2D>().pointLightOuterRadius = OuterRadius;
    }
}
