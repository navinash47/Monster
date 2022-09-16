using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 MCPos;
    private Vector3 MoonPos;
    private float diff ;
    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        diff = player.position.x - transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player==null) return;
        if (player.position.x <= maxX && player.position.x >= minX)
        {
            if (GameObject.FindWithTag("MainCamera").transform == transform)
            {
               
                MCPos = transform.position;
                MCPos.x = player.position.x;
                transform.position = MCPos;
            }
            if (GameObject.FindWithTag("Moon").transform == transform)
            {
                MoonPos = transform.position;
                MoonPos.x = player.position.x - diff;
                transform.position = MoonPos;
            }
        }

    }
}
