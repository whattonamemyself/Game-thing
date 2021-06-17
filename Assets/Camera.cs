using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (!ManagerVariables.player)
        {
            transform.Translate((GameObject.Find("Player 1").transform.position - transform.position) * 0.02F);
        }
        else
        {
            transform.Translate((GameObject.Find("Player 2").transform.position - transform.position) * 0.02F);
        }
        transform.Translate(new Vector3(0, 0, -0.2F));
    }
}
