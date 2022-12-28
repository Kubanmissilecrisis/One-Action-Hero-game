 using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class finalscript : MonoBehaviour
{
    [SerializeField]
    float movespeed = 20f;

    public Transform movePoint;

    [SerializeField]
    Transform vertic;
    void Start()
    {
       
      
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {

            if (Input.GetKey("w")) 
            {
                movePoint.parent = null;
                movePoint.position += new Vector3(0, (float)2.543, 0);
            }

            else if(Input.GetKey("s"))
            {
                movePoint.parent = null;
                movePoint.position += new Vector3(0, (float)-2.543, 0);
            }

            else
            {
                movePoint.parent = vertic;
            }
        }
    }
}
