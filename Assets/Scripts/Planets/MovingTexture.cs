using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTexture : MonoBehaviour
{

    // 서있지 못하는 행성의 씬에서
    // 1. 행성이 자전하는 것처럼 보이도록 Plane의 텍스처 움직이기
    // 2. 우주선(Landing Plane)이 자연스럽게 떠있는 것 처럼 보이기 위해 행성 Plane을 위아래로 움직이기

    private Renderer m_renderer;

    public float movingSpeed = 0.02f;
    public float offset = 0.1f;

    public float shakingSpeed = 1.5f;
    private float lerpTime = 0;
    private float yPos = 0;

    Vector2 offsetVec = Vector2.zero;
    
    void Start()
    {
        m_renderer = GetComponent<Renderer>();

        //yPos = transform.position.y;
    }


    void Update()
    {
        offset = movingSpeed * Time.time;
        m_renderer.material.mainTextureOffset = new Vector2(0, -offset);


        lerpTime += Time.deltaTime * shakingSpeed;
        yPos = Mathf.Sin(lerpTime) * 0.01f;
        transform.position += new Vector3(0, yPos, 0);
    }
}
