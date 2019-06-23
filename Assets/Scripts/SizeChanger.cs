using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public GameObject player;
    public float defaultCameraSize;
    private CinemachineVirtualCamera VCamera;
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        VCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y) ?
        Mathf.Abs(rb.velocity.x) :
        Mathf.Abs(rb.velocity.y) * 0.5f;
        VCamera.m_Lens.OrthographicSize = defaultCameraSize + speed / 2;
    }
}
