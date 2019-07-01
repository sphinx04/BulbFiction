using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    public int framerate;

    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = framerate;
    }
}
