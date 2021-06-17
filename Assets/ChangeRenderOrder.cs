using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderOrder : MonoBehaviour
{
    // Start is called before the first frame update
    private bool prev;
    void Start()
    {
        prev = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.player != prev)
        {
            if (ManagerVariables.player)
                transform.Translate(new Vector3(0, 0, 2));
            else
                transform.Translate(new Vector3(0, 0, -2));
            prev = ManagerVariables.player;
        }
    }
}
