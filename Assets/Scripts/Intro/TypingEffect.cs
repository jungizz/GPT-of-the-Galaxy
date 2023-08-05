using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI text;

    public List<string> _dialog = new List<string>();

    private int _dialogNum;

    public int CharPerSeconds;
    string targetmsg;
    int index;
    float interval;
    bool isEffect;

    // Start is called before the first frame update
    void Start()
    {
        _dialogNum = 0;
        NextDialog();
        interval = 1.0f / CharPerSeconds;
    }

    public void NextDialog()
    {
        if(_dialogNum < _dialog.Count)
        {
            Setmsg(_dialog[_dialogNum]);
            _dialogNum++;
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene("Intro2");
            }
        }
    }

    public void Setmsg(string msg)
    {
        if(isEffect)
        {
            CancelInvoke();
            EffectEnd();
        }
        targetmsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        text.text = "";
        index = 0;
        isEffect = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(text.text == targetmsg)
        {
            EffectEnd();
            return;
        }

        text.text += targetmsg[index];
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isEffect = false;
    }
}
