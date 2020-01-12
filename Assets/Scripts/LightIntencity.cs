using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntencity : MonoBehaviour
{
    public Rigidbody2D rb;
    public UnityEngine.Experimental.Rendering.Universal.Light2D playerLight;
    public float flickIntencity = 1f;
    private float intencity;
    private float innerRadius;
    // Start is called before the first frame update
    void Start()
    {
        intencity = playerLight.intensity;
        innerRadius = playerLight.pointLightInnerRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Max(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.y)) > 0.3f)
        {
            playerLight.intensity = intencity + Random.Range(-intencity, intencity) * Time.deltaTime * 10f;
            playerLight.pointLightInnerRadius = innerRadius + Random.Range(-innerRadius, innerRadius) * Time.deltaTime * 10f;
        }
        else
        {
            playerLight.intensity = intencity;
            playerLight.pointLightInnerRadius = innerRadius;
        }
        //playerLight.intensity = Mathf.Max(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.y) / 10f) * intencity;
    }

    //void OnGUI()
    //{
    //    int w = Screen.width, h = Screen.height;

    //    GUIStyle style = new GUIStyle();

    //    Rect rect = new Rect(0, 0, w, h);
    //    style.alignment = TextAnchor.LowerRight;
    //    style.fontSize = h * 2 / 100;
    //    style.normal.textColor = new Color(0.7f, 0.7f, 0.0f, 1.0f);
    //    string text = string.Format("{0:0.0}", Mathf.Max(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.y) / 10f) * intencity);
    //    GUI.Label(rect, text, style);
    //}
}
