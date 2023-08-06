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

        //달인 경우 지구로부터의 거리
        if (this.name == "10Moon") 
            rotateRadius = transform.localPosition.x - GameObject.Find("3Earth").transform.localPosition.x;
    }


    void Update()
    {
        transform.Rotate(0, selfRotateSpeed * Time.deltaTime, 0); //자전

        rotateAngle += Time.deltaTime * orbitRotateSpeed; // 공전
        if(rotateAngle < 360)
        {
            float xPos;
            float zPos;
            if (gameObject.name != "10Moon")
            {
                xPos = rotateRadius * Mathf.Sin(rotateAngle);
                zPos = rotateRadius * Mathf.Cos(rotateAngle);
            }
            else //달인 경우 계산된 값에 원점(태양)과 지구 사이의 거리를 더해줌
            {
                xPos = rotateRadius * Mathf.Sin(rotateAngle) + GameObject.Find("3Earth").transform.localPosition.x;
                zPos = rotateRadius * Mathf.Cos(rotateAngle) + GameObject.Find("3Earth").transform.localPosition.z;
            }

            transform.localPosition = new Vector3(xPos, 0, zPos);
        }
        
    }
}
