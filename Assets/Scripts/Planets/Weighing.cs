using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weighing : MonoBehaviour
{
    public Text weightText;
    public AudioSource FinishSound;

    private float weight;
    private float gravity;

    private bool isfinish = false;

    void Start()
    {
        gravity = GameObject.Find("XR Origin").GetComponent<ConstantForce>().force.y * (-1);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WeightTarget"))
        {
            //행성에서의 무게 = 질량 X (행성 중력/9.8)
            weight = collision.gameObject.GetComponent<Rigidbody>().mass * (gravity/9.8f);

            StartCoroutine(IncreaseWeight(weight));
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WeightTarget"))
        {
            weightText.text = "0";
        }
    }

    IEnumerator IncreaseWeight(float weight)
    {
        weightText.text = (float.Parse(weightText.text) + 0.1).ToString();
        
        yield return new WaitForSeconds(0.01f);

        if (float.Parse(weightText.text) <= weight)
        {
            StartCoroutine(IncreaseWeight(weight));
        }else isfinish = true;

    }

    private void Update()
    {
        if (isfinish) FinishSound.Play(); isfinish = false;
    }
}
