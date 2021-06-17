using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static float checkpointx;
    public static float checkpointy;
    void Start()
    {
        checkpoint(3, -1.8F);
        die();
    }
    public static void checkpoint(float xpos, float ypos)
    {
        checkpointx = xpos;
        checkpointy = ypos;
    }
    public static void die()
    {
        GameObject.Find("Player 1").gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.Find("Player 1").transform.SetPositionAndRotation(new Vector3(checkpointx, checkpointy, GameObject.Find("Player 1").transform.position.z), Quaternion.identity);
        GameObject.Find("Player 2").gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.Find("Player 2").transform.SetPositionAndRotation(new Vector3(checkpointx, checkpointy, GameObject.Find("Player 2").transform.position.z), Quaternion.identity);

        GameObject.Find("Chain").transform.SetPositionAndRotation(new Vector3(checkpointx, checkpointy - 1, 0), Quaternion.identity);
        GameObject.Find("Chain").gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        for (int i = 1; i < 16; i++)
        {
            GameObject.Find("Chain (" + i + ")").transform.SetPositionAndRotation(new Vector3(checkpointx, checkpointy - i - 1, 0), Quaternion.identity);
            GameObject.Find("Chain (" + i + ")").gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //GameObject.Find("Chain (" + i + ")").gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
             ManagerVariables.player = !ManagerVariables.player;
        if (Input.GetKeyDown(KeyCode.R))
            die();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ManagerVariables.length-=0.02F;
            if (ManagerVariables.length < 2)
                ManagerVariables.length = 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ManagerVariables.length+=0.02F;
            if (ManagerVariables.length > 16)
                ManagerVariables.length = 16;
        }
        if ((GameObject.Find("Player 1").transform.position - GameObject.Find("Player 2").transform.position).magnitude-0.5F > ManagerVariables.length)
            ManagerVariables.length = (GameObject.Find("Player 1").transform.position - GameObject.Find("Player 2").transform.position).magnitude-0.5F;
    }
}
