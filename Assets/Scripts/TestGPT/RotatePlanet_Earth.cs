using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet_Earth : MonoBehaviour
{
    //private float degreePerSecond = 20f;

    public Transform hand;  //컨트롤러의 Transform
    public Transform planet;    //행성의 Transform

    private bool isRotating = false;
    private Vector3 initialHandPosition;
    private Quaternion initialRotation;
    private float rotationSpeed = 0.6f;   //돌리는 속도

    void Update()
    {
        //transform.Rotate(Vector3.up * Time.deltaTime * degreePerSecond);  //혼자서 자전하게 하는 코드
        planet.position = new Vector3(-10.71f, -11.91f, 16.03f);   //행성 좌표 고정

        if (isRotating)
        {
            RotateObject();
        }
    }

    public void StartRotating()
    {
        isRotating = true;
        initialHandPosition = hand.position;
        initialRotation = transform.rotation;
    }

    public void StopRotating()
    {
        isRotating = false;
    }

    private void RotateObject()
    {
        Vector3 currentHandPosition = hand.position;
        Vector3 direction = (currentHandPosition - initialHandPosition).normalized;

        // 손의 움직임 방향에 따라 회전 각도 계산
        float horizontalAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float verticalAngle = Mathf.Asin(direction.y) * Mathf.Rad2Deg;

        // 회전 각도를 적용하여 물체를 회전
        transform.rotation = initialRotation * Quaternion.Euler(verticalAngle * rotationSpeed, -horizontalAngle * rotationSpeed, 0f);
    }
}
