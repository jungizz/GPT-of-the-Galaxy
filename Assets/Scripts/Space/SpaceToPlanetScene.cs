using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToPlanetScene : MonoBehaviour
{
    public void changePlanetScene()
    {
        SceneManager.LoadScene(this.name);
    }
}
