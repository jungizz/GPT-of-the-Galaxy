using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    Vector3 Camerafinal = new Vector3(8.01f, 17.75f, -13.95f);
    public GameObject obj;

    void Start()
    {
        transform.position = new Vector3(70.7f, 77.5f, -54.9f);
    }

    void Update()
    {
      
        this.obj.transform.position = Vector3.Slerp(obj.transform.position, Camerafinal, 0.0001f);
    }

}