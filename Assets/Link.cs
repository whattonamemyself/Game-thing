using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    // Start is called before the first frame update
    private int idx;
    public Rigidbody2D thing;
    void Start()
    {
        string[] temp = gameObject.name.Split('(');
        if (temp.Length == 1)
        {
            idx = 0;
        }
        else {
            print(temp[1]);
            string[] temp2 = temp[1].Split(')');
            idx = int.Parse(temp2[0]);
        }
        idx++;
        //idx++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.CeilToInt(ManagerVariables.length) < idx)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            thing.AddForce((GameObject.Find("Player 2").transform.position - transform.position) * 0.01F);
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (Mathf.CeilToInt(ManagerVariables.length) == idx)
        {
            thing.AddForce((GameObject.Find("Player 2").transform.position - transform.position) * 0.03F);
        }
    }
}
