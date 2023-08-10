using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    static public BGM instance;
    public GameObject bgm;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = bgm.GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(bgm);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Intro2")
        {
            if (audio.isPlaying) return;    //if audio is playing, keep playing
            else
            {
                audio.Play();   //if audio is not playing, start to play the audio
            }
        }
        else if (SceneManager.GetActiveScene().name == "Intro2")
        {
            Destroy(bgm);
        }

    }

}