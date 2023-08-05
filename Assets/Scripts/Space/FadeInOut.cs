using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image fadeOutUIImage;
    public float fadeSpeed = 1f;

    bool FadeDir;      // true -> Alpha = 1  , false -> Alpha = 0	

    private void Start()
    {
        FadeDir = true;
    }

    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeDir = false;
            StartCoroutine(Fade(FadeDir));
        }
        if (Input.GetMouseButtonDown(1))
        {
            FadeDir = true;
            StartCoroutine(Fade(FadeDir));
        }
    }
    */

    
    public void FadeIn()
    {
        FadeDir = false;
        StartCoroutine(Fade(FadeDir));
    }

    public void FadeOut()
    {
        FadeDir = true;
        StartCoroutine(Fade(FadeDir));
    }

    private IEnumerator Fade(bool FDir)
    {
        float alpha = (FDir) ? 1 : 0;
        float fadeEndValue = (FDir) ? 0 : 1;
        if (FDir)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, FDir);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, FDir);
                yield return null;
            }
        }
    }

    private void SetColorImage(ref float alpha, bool FDir)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((FDir) ? -1 : 1);
    }
}
