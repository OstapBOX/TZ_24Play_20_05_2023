using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAim : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
