using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;

    private float xPos, zPos;

    private void Update()
    {
        xPos = Player.transform.localPosition.x;
        zPos = Player.transform.localPosition.z;
        transform.localPosition = new Vector3(xPos, 0, zPos);
    }
}
