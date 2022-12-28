using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class horimove : MonoBehaviour
{
    [SerializeField]
    float movespeed = 5f;

    public Transform movePoint;

    public Transform hori;
    void Start()
    {
      

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {

            if (Input.GetKey("d"))
            {
                movePoint.parent = null;
                movePoint.position += new Vector3((float)2.543, 0, 0);
            }

            else if (Input.GetKey("a"))
            {
                movePoint.parent = null;
                movePoint.position += new Vector3((float)-2.543, 0, 0);
            }
            else
            {
                movePoint.parent = hori;
            }
        }
    }
}