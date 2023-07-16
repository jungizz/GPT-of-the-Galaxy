using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mars_Button : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Intro_Button()
    {
        GameObject.Find("Mars_Canvas").transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(WaitAndPrint(2.0f));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        GameObject.Find("Mars_Canvas").transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("2초가 지났습니다");
    }

    public void Talk_Button()
    {
        GameObject.Find("Mars_Canvas").transform.GetChild(1).gameObject.SetActive(false);
    }
}
