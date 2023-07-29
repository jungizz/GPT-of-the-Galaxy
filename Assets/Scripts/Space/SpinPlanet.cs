using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanet : MonoBehaviour
{
    public float selfRotateSpeed; //자전 각속도

    public float orbitRotateSpeed; //공전 각속도
    private float rotateRadius; //회전 반지름
    private float rotateAngle; //회전 각도


    void Start()
    {
        rotateRadius = transform.localPosition.x; //원점(태양)으로부터의 거리
    }


    void Update()
    {
        transform.Rotate(0, selfRotateSpeed * Time.deltaTime, 0); //자전

        rotateAngle += Time.deltaTime * orbitRotateSpeed;
        if(rotateAngle < 360)
        {
            float xPos = rotateRadius * Mathf.Sin(rotateAngle);
            float zPos = rotateRadius * Mathf.Cos(rotateAngle);

            //if (gameObject.name == "Moon")

            transform.localPosition = new Vector3(xPos, 0, zPos);
        }
        
    }
}
