using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    //public TextMeshProUGUI text;
    public Text text;
    //public Text tx;

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
        Setmsg(_dialog[_dialogNum]);
        _dialogNum++;
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
