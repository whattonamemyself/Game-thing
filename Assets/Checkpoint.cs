using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float checkpointx;
    public float checkpointy;
    private SpriteRenderer SpriteR;
    private Sprite[] sprites;
    private bool checkpoint = false;
    void Start()
    {
        SpriteR = GetComponent<SpriteRenderer>();
        transform.SetPositionAndRotation(new Vector3(checkpointx, checkpointy, transform.position.z), Quaternion.identity);
        sprites = Resources.LoadAll<Sprite>("blue");
        SpriteR.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if((GameObject.Find("Player 1").transform.position - transform.position).magnitude < 2)
        {
            Manager.checkpoint(checkpointx, checkpointy);
            checkpoint = true;
        }
        if ((GameObject.Find("Player 2").transform.position - transform.position).magnitude < 2)
        {
            Manager.checkpoint(checkpointx, checkpointy);
            checkpoint = true;
        }
        if (checkpoint)
        {
            if (!ManagerVariables.player)
            {
                SpriteR.sprite = sprites[1];
            }
            else
            {
                SpriteR.sprite = sprites[3];
            }
        }
        else
        {
            if (!ManagerVariables.player)
            {
                SpriteR.sprite = sprites[0];
            }
            else
            {
                SpriteR.sprite = sprites[2];
            }
        }
    }
}
