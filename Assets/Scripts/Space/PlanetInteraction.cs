using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetInteraction : MonoBehaviour
{ 
    public GameObject player;
    public Vector3 offset = new Vector3 (0, 1, -10); //행성과 카메라 사이 간격

    private bool moveCam = false;
    private bool fixCam = false;


    public void changePlanetScene()
    {
        SceneManager.LoadScene(this.name);
    }
    public void FixCameraToPlanet()
    {
        moveCam = true;
    }

    private void Update()
    {
        if (moveCam)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, transform.position, 1f);
            moveCam = false;
            fixCam = true;
        }
        if (fixCam)
        {
            player.transform.position = transform.position + offset;
        }
    }
}
